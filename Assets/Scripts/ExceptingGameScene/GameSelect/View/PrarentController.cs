using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;
using Common.Model;
using System;

public class PrarentController : MonoBehaviour
{
    ClearDateKeeper _clearDateKeeper = new ClearDateKeeper();
    private int count = 0;
    private Subject<int> _sceneMoveCallSubject = new Subject<int>();
    public IObservable<int> GetObservable() => _sceneMoveCallSubject;

    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Select(x => (int)Input.GetAxisRaw("Horizontal"))
            .Where(x => x != 0)
            .ThrottleFirstFrame(10)
            .Subscribe(x =>
            {
                if (count == 0 && x < 0) return;
                if (count == transform.childCount - 1 && x > 0) return;
                //transform.position += new Vector3(-(x * 5), 0, 0);
                transform.DOMoveX(transform.position.x + -(x * 7), 0.1f);
                count += x;
            }).AddTo(this);

        this.UpdateAsObservable()
            .Where(x => Input.GetKeyDown(KeyCode.Space))
            .Where(x => _clearDateKeeper.GetClearStageNum() >= count)
            .Subscribe(x =>
            {
                _sceneMoveCallSubject.OnNext(count + 1);
            }).AddTo(this);
    }
}
