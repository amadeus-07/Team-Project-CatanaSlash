using System.Collections;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class SpawnSequenceRunner : MonoBehaviour
    {
        [Inject] private SpawnSequence sequence;
        [SerializeField] private SpawnPointProvider pointsProvider;

        [Inject] private IObjectResolver resolver;
        [Inject] private IEnemyCounter counter;

        private void Start() => StartCoroutine(Run());

        private IEnumerator Run()
        {
            foreach (var step in sequence.steps)
            {
                yield return new WaitForSeconds(step.delay);

                foreach (var item in step.spawnStepItems)
                {
                    var points = pointsProvider.GetAll(item.side);

                    foreach (var point in points)
                    {
                        for (int i = 0; i < item.amount; i++)
                        {
                            var enemy = resolver.Instantiate(
                                item.enemy,
                                point.position,
                                point.rotation,
                                transform
                            );

                            counter.AddEntity(enemy);
                        }
                    }
                }
            }
        }
    }
}
