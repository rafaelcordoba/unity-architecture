using System;
using MyGame.Application.Hello;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MyGame.Presentation.Hello
{
    public class HelloWorldPresenter : MonoBehaviour
    {
        [SerializeField] private Button helloButton;
        [SerializeField] private TMP_Text greetingText;
        [SerializeField] private TMP_InputField nameInput;
        
        [Inject] private HelloUseCase _useCase;

        private void Awake()
        {
            greetingText.text = string.Empty;
        }

        private void Start()
        {
            helloButton.onClick.AddListener(OnHelloButtonClicked);
        }

        private void OnDestroy()
        {
            helloButton.onClick.RemoveListener(OnHelloButtonClicked);
        }

        private async void OnHelloButtonClicked()
        {
            greetingText.text = "Loading...";
            var result = await _useCase.HelloAsync(nameInput.text);
            greetingText.text = result;
        }
    }
}
