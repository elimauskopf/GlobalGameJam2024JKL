using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SpeechLib;

public class TextToSpeech : MonoBehaviour
{
    SpVoice voice = new SpVoice();

    private void Update()
    {
              
    }

    public void ReadText(string s)
    {
        voice.Speak(s, SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
    }
}