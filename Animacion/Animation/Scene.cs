using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Animacion
{
    public class Scene
    {
        public List<Action> ListOfActions{ get; set; }

        public int lastIndex { get; set; }

        public Scene()
        {
            ListOfActions = new List<Action>();
            lastIndex = 0;
        }

        public Scene(List<Action> listOfActions)
        {
            ListOfActions = listOfActions;
            lastIndex = 0;
        }

        public void AddAction(Action newAction)
        {
            ListOfActions.Add(newAction);
        }

        public void InsertAction(int index, Action newAction)
        {
            ListOfActions.Insert(index, newAction);
        }

        public int ExecuteAction(int actionIndex)
        {
            ListOfActions[actionIndex].Apply();
            lastIndex = actionIndex;
            return actionIndex;
        }

        public int ExecuteNextAction()
        {
            int nextIndex = (lastIndex + 1) > ListOfActions.Count - 1 ? 0 : lastIndex + 1;
            ListOfActions[nextIndex].Apply();
            lastIndex = nextIndex;
            return nextIndex;
        }
    }
}