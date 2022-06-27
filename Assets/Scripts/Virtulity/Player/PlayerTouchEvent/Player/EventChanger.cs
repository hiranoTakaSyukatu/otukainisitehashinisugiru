using System;
using Connector.Player;
using Reality.TouchObject;
using Virtulity.EventDataManager;
using UniRx;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;
using Signal;
using Signal.Expansion;

namespace Virtulity
{
    namespace Player
    {
        public class EventChanger : IObjectRecevetable, IEventNumSentable
        {
            // Playerが当たった物を取得してイベントを発行する
            // 当たった物別で発行するイベントを変更

            Subject<EventDataBaseInfo> _eventNumSubject = new Subject<EventDataBaseInfo>();
            Subject<Unit> _desSubject = new Subject<Unit>();

            DatabaseType[] datebaseTypes = new DatabaseType[]
                {
                    DatabaseType.NULL,
                    DatabaseType.DEAD,
                    DatabaseType.CONVERSATION,
                    DatabaseType.OTHER
                };

            DataBaseStage[] dataBaseStages = new DataBaseStage[]
                {
                    DataBaseStage.NULL,
                    DataBaseStage.STAGE_01,
                    DataBaseStage.STAGE_02,
                    DataBaseStage.STAGE_03,
                    DataBaseStage.STAGE_04,
                    DataBaseStage.STAGE_05,
                    DataBaseStage.STAGE_06,
                    DataBaseStage.STAGE_07,
                    DataBaseStage.STAGE_08,
                    DataBaseStage.STAGE_09,
                    DataBaseStage.STAGE_10,
                    DataBaseStage.STAGE_11,
                    DataBaseStage.STAGE_12,
                    DataBaseStage.STAGE_13,
                    DataBaseStage.STAGE_14,
                    DataBaseStage.STAGE_15,
                    DataBaseStage.STAGE_16,
                    DataBaseStage.STAGE_17,
                    DataBaseStage.STAGE_18,
                    DataBaseStage.STAGE_19,
                    DataBaseStage.STAGE_20,
                };

            public EventChanger()
            {
                InterfaceExpansion.Bind(this);
            }


            private EventDataBaseInfo CreatDataStructure(TouchObjectType data)
            {
                int temp = (int)data;
                int dbType = (temp / 100) % 100;
                int num = temp % 100;
                int stageNum = (temp / 10000) % 100;

                EventDataBaseInfo tmp = new EventDataBaseInfo();

                tmp.datebaseType = datebaseTypes[dbType];
                tmp.gimmickNum = num;
                tmp.stageNum = (int)dataBaseStages[stageNum];
                return tmp;
            } 

            IObservable<Unit> IEventNumSentable.GetEventDestroyObserble()
            {
                return _desSubject;
            }

            IObservable<EventDataBaseInfo> IEventNumSentable.GetEventNumObserble()
            {
                return _eventNumSubject;
            }

            // EnumをイベントIDに変換してイベントを発火させる
            void IObjectRecevetable.ObjectRecevetable(TouchObjectType data)
            {
                _eventNumSubject.OnNext(CreatDataStructure(data));
            }

            void IObjectRecevetable.OnPlayEventRelease()
            {
                _desSubject.OnNext(Unit.Default);
            }

            
        }
    }

}

