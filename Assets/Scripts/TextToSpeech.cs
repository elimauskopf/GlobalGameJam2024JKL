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
        if (Input.GetKeyDown(KeyCode.S))

            voice.Speak("FUCK YOU ELI", SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
    }
}