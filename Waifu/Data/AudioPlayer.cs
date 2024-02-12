﻿using System.IO;
using System.Windows.Forms.VisualStyles;
using NAudio.Wave;

namespace Waifu.Data;

public class AudioPlayer
{
    private readonly Settings _settings;

    public AudioPlayer(Settings settings)
    {
        _settings = settings;
    }

    public async Task PlayMp3FromByteArrayAsync(byte[] mp3Data)
    {
        var currentSettings = await _settings.GetOrCreateSettings();
        int audioOutDeviceId = currentSettings.AudioPlayerDeviceId;
        using (MemoryStream mp3Stream = new MemoryStream(mp3Data))
        {
            using (Mp3FileReader mp3FileReader = new Mp3FileReader(mp3Stream))
            {
                using (WaveOutEvent waveOut = new WaveOutEvent())
                {
                    if (audioOutDeviceId != -1)
                    {
                        waveOut.DeviceNumber = audioOutDeviceId;
                    }
                    else
                    {
                        // Use the default audio output device
                        waveOut.DeviceNumber = -1;
                    }

                    waveOut.Init(mp3FileReader);
                    waveOut.Play();

                    // Wait asynchronously until playback is finished
                    await Task.Run(async () =>
                    {
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        }
                    });
                }
            }
        }
    }
}