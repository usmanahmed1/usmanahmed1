using DG.Tweening;
using UnityEngine;
using System.Threading.Tasks;

public class DoorHandler : MonoBehaviour
{
    public bool isDoor;
    public bool doubleDoor;
    public Vector3 openPos;
    public Vector3 closePos;
    bool opened;
    Transform myTransform;

    private void Start()
    {
        myTransform = transform;
    }
    bool openCompleted = true;
    public void OpenCloseDoor()
    {
        if (openCompleted)
        {
            SoundManager.instance.PlayEffect(AudioClipsSource.Instance.doorClip);
            opened = !opened;
            if (opened)
                OpenDoor();
            else CloseDoor();
        }
    }

    async void OpenDoor()
    {
        if (isDoor && doubleDoor)
        {
            openCompleted = false;
            myTransform = transform.parent;
            var openPos1 = myTransform.GetChild(0).GetComponent<DoorHandler>().openPos;
            myTransform.GetChild(0).DOLocalRotate(openPos1, .5f).SetEase(Ease.Linear).SetUpdate(true);
            var openPos2 = myTransform.GetChild(1).GetComponent<DoorHandler>().openPos;
            myTransform.GetChild(1).DOLocalRotate(openPos2, .5f).SetEase(Ease.Linear).SetUpdate(true);
            await Task.Delay(500);
            openCompleted = true;
        }
        else if (!isDoor)
        {
            openCompleted = false;
            myTransform.DOLocalMove(openPos, .5f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(delegate
            {
                openCompleted = true;
            });
        }
        else
        {
            openCompleted = false;
            myTransform.DOLocalRotate(openPos, .5f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(delegate
            {
                openCompleted = true;
            });
        }
    }

    async void CloseDoor()
    {
        if (isDoor && doubleDoor)
        {
            openCompleted = false;
            myTransform = transform.parent;
            var closePos1 = myTransform.GetChild(0).GetComponent<DoorHandler>().closePos;
            myTransform.GetChild(0).DOLocalRotate(closePos1, .5f).SetEase(Ease.Linear).SetUpdate(true);
            var closePos2 = myTransform.GetChild(1).GetComponent<DoorHandler>().closePos;
            myTransform.GetChild(1).DOLocalRotate(closePos2, .5f).SetEase(Ease.Linear).SetUpdate(true);
            await Task.Delay(500);
            openCompleted = true;
        }
        else if (!isDoor)
        {
            openCompleted = false;
            myTransform.DOLocalMove(closePos, .5f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(delegate
            {
                openCompleted = true;
            });
        }
        else
        {
            openCompleted = false;
            myTransform.DOLocalRotate(closePos, .5f).SetEase(Ease.Linear).SetUpdate(true).OnComplete(delegate
            {
                openCompleted = true;
            });
        }
    }
}
