using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using System;
using Connector.PlayerMove;
using static Virtulity.PlayerMove.PlayerWalkDirType;

namespace Virtulity
{
    namespace PlayerMove
    {
        /* プレイヤーの動きを計算k結果をイベントとして発火するクラス
         * PlayerCoreをコンポジットしていて値の変換はすべてこのクラスのインターフェイスから変更される
         * 
         * 要リファクタリング
         * 変数の保持は計算クラスではなく挙動側からすべてもらうべき
         * できる限りPlayerCoreの責務を減らす
         */
        public class PlayerHorizonMove : IInputReceivable, IPlayerWalkInfoSender
        {
            [Inject]
            private PlayerCore _core;
            [Inject]
            private IPlayerStateSettable _stateSettable;
            [Inject]
            private IPlayerTransformSettable _transformSettable;
            [Inject]
            private IPlayerWalkDirTypeSettable _walkDirTypeSettable;
            private Queue<Vector3> _inputValueQueue = new Queue<Vector3>(QUEUE_MAX_NUM);
            private Subject<Vector3> _playerVec3Subject = new Subject<Vector3>();
            private Subject<PlayerWalkDirType> _playerWalkDirTypeSubject = new Subject<PlayerWalkDirType>();
            private Vector3 beforeInputValue = Vector2.zero;
            const float RUN_MUL_SPEED = 1.7f;
            const float CUL_SPEED = 0.005f;
            const int QUEUE_MAX_NUM = 120;

            public event Func<Vector3, float> GetObjectDistance;

            // 現在のPlayerStateを変更
            void IInputReceivable.IsRunButtonStateChange(bool boolean)
            {
                var result = boolean ? PlayerWalkType.RUN : PlayerWalkType.WALK;
                _stateSettable.StateChange(result);
            }

            // 次のプレイヤーの座標の計算
            void IInputReceivable.CurrentMoveDir(Vector3 inputValue)
            {
                // 入力をまとめるためにキューで加工する
                bool isEnqueuable = _inputValueQueue.Count == 0 && inputValue != Vector3.zero;
                bool isInputValueChange = inputValue != beforeInputValue;
                if (isEnqueuable || isInputValueChange)
                {
                    EnqueueToInputValue(inputValue);
                }
                beforeInputValue = inputValue;
                var dequeueValue = Vector3.zero;
                // キューからInputの加工された情報を受け取る
                if (_inputValueQueue.Count > 0)
                {
                    dequeueValue = _inputValueQueue.Dequeue();
                }
                // 菱形移動に変形
                var rhombusValue = GetRhombusDir(dequeueValue);
                // 走る状態のときのスピード補正
                var resultValue = RunSpeedMul(rhombusValue);
                resultValue *= CUL_SPEED;
                // 方向を取得
                bool isDirMove = IsDirNove(rhombusValue);

                var resultPos = _core.PlayerVec3;
                resultPos += isDirMove ? resultValue : Vector3.zero;

                //  イベントを発火
                if (resultValue != Vector3.zero)
                {
                    _playerVec3Subject.OnNext(resultPos);
                    RunAnimationChange(dequeueValue);
                }
                else
                {
                    StayAnimationChange(_core.PlayerWalkDirType);
                }

                _transformSettable.TransformPositionChange(resultPos);
            }

            // 菱形移動に変形
            private Vector3 GetRhombusDir(Vector3 inputValue)
            {
                var resultValue = inputValue * Time.deltaTime;
                resultValue = Quaternion.Euler(0, 0, -45) * resultValue;
                resultValue = resultValue.normalized;
                resultValue.x *= 2f;
                return resultValue;
            }

            // 走る状態のときのスピード補正
            private Vector3 RunSpeedMul(Vector3 resultValue)
            {
                if (_core.State == PlayerWalkType.RUN)
                {
                    resultValue.x *= RUN_MUL_SPEED;
                    resultValue.y *= RUN_MUL_SPEED;
                }
                return resultValue;
            }

            private void EnqueueToInputValue(Vector3 inputValue)
            {
                _inputValueQueue.Clear();
                if (inputValue.x > 0) LoopInputEnqueue(Vector3.right);
                if (inputValue.x < 0) LoopInputEnqueue(Vector3.left);
                if (inputValue.y > 0) LoopInputEnqueue(Vector3.up);
                if (inputValue.y < 0) LoopInputEnqueue(Vector3.down);
                if (_inputValueQueue.Count == QUEUE_MAX_NUM / 2) LoopInputEnqueue(_inputValueQueue.Peek());
            }

            private void LoopInputEnqueue(Vector3 vec3)
            {
                for (int i = 0; i < QUEUE_MAX_NUM / 2; i++)
                {
                    _inputValueQueue.Enqueue(vec3);
                }
            }

            IObservable<Vector3> IPlayerWalkInfoSender.GetPlayerTransformObservable()
            {
                return _playerVec3Subject;
            }

            IObservable<PlayerWalkDirType> IPlayerWalkInfoSender.GetPlayerWalkTypeObservable()
            {
                return _playerWalkDirTypeSubject;
            }

            private void RunAnimationChange(Vector3 vec3)
            {
                if (vec3.y > 0)
                {
                    _playerWalkDirTypeSubject.OnNext(UP);
                    _walkDirTypeSettable.DirChange(UP);
                }
                else if (vec3.y < 0)
                {
                    _playerWalkDirTypeSubject.OnNext(DOWN);
                    _walkDirTypeSettable.DirChange(DOWN);
                }
                else if (vec3.x > 0)
                {
                    _playerWalkDirTypeSubject.OnNext(RIGHT);
                    _walkDirTypeSettable.DirChange(RIGHT);
                }
                else if (vec3.x < 0)
                {
                    _playerWalkDirTypeSubject.OnNext(LEFT);
                    _walkDirTypeSettable.DirChange(LEFT);
                }

            }
            private void StayAnimationChange(PlayerWalkDirType walkDirType)
            {
                if (walkDirType == UP) _playerWalkDirTypeSubject.OnNext(UP_STAY);
                if (walkDirType == DOWN) _playerWalkDirTypeSubject.OnNext(DOWN_STAY);
                if (walkDirType == RIGHT) _playerWalkDirTypeSubject.OnNext(RIGHT_STAY);
                if (walkDirType == LEFT) _playerWalkDirTypeSubject.OnNext(LEFT_STAY);
            }


            private bool IsDirNove(Vector3 dir)
            {
                const float STOP_DISTANCE = 0.2f;
                float distance = GetObjectDistance(dir);
                if (STOP_DISTANCE < distance) return true;
                return false;
            }
        }
    }
}

