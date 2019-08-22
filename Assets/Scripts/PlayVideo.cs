using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour
{
    private int currentModule;

    [SerializeField]
    private List<VideoClip> videos;
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private Image displayImage;
    [SerializeField]
    private List<GameObject> contentContainers;

    private VideoClip videoToPlay;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
    }

    public void playModule(int module)
    {
        if(videoPlayer != null && videoPlayer.isPlaying) videoPlayer.Stop();
        currentModule = module;
        Application.runInBackground = true;
        videoToPlay = videos[module];
        StartCoroutine(playVideo());
        videoPlayer.loopPointReached += EndReached;
    }

    public void EndReached(VideoPlayer player)
    {
        displayImage.gameObject.SetActive(true);
        contentContainers[currentModule].SetActive(true);
        Debug.Log("Set active?");
    }

     IEnumerator playVideo()
    {
      
        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();

        //We want to play from video clip not from url
        
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.aspectRatio = 0;

        // Vide clip from Url
        //videoPlayer.source = VideoSource.Url;
        //videoPlayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";


        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;

        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        Debug.Log("Done Playing Video");
}
}
