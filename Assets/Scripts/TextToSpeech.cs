using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SpeechLib;

public class TextToSpeech : MonoBehaviour
{
    SpVoice voice = new SpVoice();

    private void Start()
    {
        SpVoice voice = new SpVoice();
        //voice.Voice = voice.GetVoices("gender=female").Item(0);
    }

    public void ReadText(string s)
    {
        //voice.Skip("Sentence", 5);
        voice.Speak(s, SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
    }
}