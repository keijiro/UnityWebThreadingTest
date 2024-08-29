using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;

public sealed class AsyncTest : MonoBehaviour
{
    (int, int) _asyncCounts;

    async void AsyncTestAwaitable()
    {
        while (true)
        {
            await Awaitable.WaitForSecondsAsync(0.5f);
            _asyncCounts.Item1++;
        }
    }

    async void AsyncTestThreading()
    {
        while (true)
        {
            await Task.Delay(500);
            _asyncCounts.Item2++;
        }
    }

    async void Start()
    {
        AsyncTestAwaitable();
        AsyncTestThreading();
    }

    void Update()
    {
        var text = $"Frame count: {Time.frameCount}\n" +
                   $"Async count: {_asyncCounts.Item1}, {_asyncCounts.Item2}";

        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Label>().text = text;
    }
}
