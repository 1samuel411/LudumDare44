using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{

    public float transitionTime = 2;

    public int storyPos;

    public PlayerController playerController;

    [System.Serializable]
    public struct Room
    {
        public string name;
        public GameObject roomHolder;
        public GameObject collisionHolder;
        public Transform enterPoint, enterPointAlt;
        public SpriteRenderer cover;
    }

    public Room[] rooms;

    public static RoomSystem instance;

    private bool entering;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rooms[0].cover.color = GetColor(0);
        rooms[0].collisionHolder.SetActive(true);
        for(int i = 1; i < rooms.Length; i++)
        {
            rooms[i].cover.color = GetColor(1);
            rooms[i].collisionHolder.SetActive(false);
        }
    }

    void Update()
    {
        
    }


    public async void EnterRoom(string from, string to, bool alt)
    {
        if (entering)
            return;

        entering = true;
        Room a = FindRoom(from);
        Room b = FindRoom(to);

        SwapRoomCovers(a, b);

        a.collisionHolder.SetActive(false);
        b.collisionHolder.SetActive(false);

        await playerController.MoveTo(alt ? b.enterPointAlt.position.x : b.enterPoint.position.x);
        entering = false;

        //a.collisionHolder.SetActive(false);
        //b.collisionHolder.SetActive(true);
    }

    async void SwapRoomCovers(Room a, Room b)
    {
        while(a.cover.color.a <= 1 || b.cover.color.a >= 0)
        {
            float aAlpha = a.cover.color.a;
            aAlpha = Mathf.Lerp(aAlpha, 1.1f, transitionTime * Time.deltaTime);
            a.cover.color = GetColor(aAlpha);

            float bAlpha = b.cover.color.a;
            bAlpha = Mathf.Lerp(bAlpha, -0.1f, transitionTime * Time.deltaTime);
            b.cover.color = GetColor(bAlpha);

            await Task.Delay(1);
        }

        a.cover.color = GetColor(1);
        b.cover.color = GetColor(0);
    }

    private Color GetColor(float alpha)
    {
        Color color = Color.black;
        color.a = alpha;
        return color;
    }

    Room FindRoom(string name)
    {
        for(int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].name == name)
                return rooms[i];
        }

        return new Room();
    }

    public void IncrementStory()
    {
        storyPos++;
    }
}
