using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartScene
{
    namespace StartCanvas
    {
        public class StartSceneStartCanvasManager : MonoBehaviour
        {
            private PannelChange _pannelChange;

            public void Start()
            {
                PannelChangeInit();
            }

            /// <summary>
            /// ��ʼ�������л���
            /// </summary>
            private void PannelChangeInit()
            {
                _pannelChange = new PannelChange();
                _pannelChange.AddPannel("Title", transform.Find("TitlePannel").GetComponent<CanvasGroup>());
                _pannelChange.AddPannel("Main", transform.Find("MainPannel").GetComponent<CanvasGroup>());
                _pannelChange.AddPannel("Option", transform.Find("OptionPannel").GetComponent<CanvasGroup>());
                _pannelChange.ChangeToPannel("Title");
            }

            /// <summary>
            /// �л���ʾ��Pannel
            /// </summary>
            /// <param name="name">Ҫ�л�����Pannel����</param>
            public void TogglePannel(string name)
            {
#if UNITY_EDITOR
                if (false == _pannelChange.ChangeToPannel(name))
                {
                    Debug.Log($"StartSceneStartCanvasManager�����л���{{{name}}}ʧ��");
                }
#else
                _pannelChange.ChangeToPannel(name)
#endif
            }

            /// <summary>
            /// <para/>�˳�
            /// <para/>ֱ���˳�����
            /// </summary>
            public void Exit()
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
            }
        }
    }
}