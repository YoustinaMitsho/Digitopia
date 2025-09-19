using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        Color currentColor = Color.white;
        float currentAlpha = 0f;

        if (!text) return;

        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0f)
            {
                ScriptPlayable<SubtitleBehaviour> inputPlayable = (ScriptPlayable<SubtitleBehaviour>)playable.GetInput(i);

                SubtitleBehaviour input = inputPlayable.GetBehaviour();
                currentText = input.SubtitleText;
                currentColor = input.SubtitleColor;
                currentAlpha = inputWeight;
            }
        }

        text.text = currentText;
        text.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentAlpha);
    }
}
