﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace JamGame
{
    public class GameRunning : IGameState
    {
        string ResPath = "Planet/GameMap";

        //IPlanetState m_PlanState;

        //GamePlanet m_Plant;

        //TestBeanEmitter m_Emit;

        //public float m_PlantRotateSpeed = 90.0f;

        //public float m_ResisAcceleration = 10.0f;

        //float m_CurrentSpeed = 0;
        //float m_CurrentResis = 0;

        protected GameManager m_Game;

        public GameRunning(GameManager gamemgr)
        {
        }

        public void Enter()
        {
            GameObject pPlanetObjIns = Resources.Load(ResPath) as GameObject;
            if(pPlanetObjIns == null)
            {
                Debug.LogError("Not Find Planet Res");
                return;
            }

            GameObject MapObj = GameObject.Instantiate(pPlanetObjIns);

            //m_Emit = MapObj.GetComponentInChildren<TestBeanEmitter>();

            //m_Plant = MapObj.GetComponentInChildren<GamePlanet>();

            //m_Plant.ChangeState(new PlanetReady(m_Plant));
        }

        public void Execute(float dt)
        {
            //m_PlanState.Execute(dt);
            //m_Plant.GameUpdate(dt);

            //m_Emit.UpdateEmit(dt);
        }

        public void Exit()
        {
            //throw new NotImplementedException();
        }

        
    }
}
