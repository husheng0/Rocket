﻿using System;
using Rocket.API.Commands;
using Rocket.API.Permissions;

namespace Rocket.Tests {
    public class TestConsoleCaller : IConsoleCommandCaller
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IIdentifiable other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IIdentifiable other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(string other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(string other)
        {
            throw new NotImplementedException();
        }

        public string Id => "Console";
        public string Name => "Console";
        public Type CallerType => typeof(TestConsoleCaller);
        public void SendMessage(string message)
        {
            Console.WriteLine("[SendMessage] " + message);
        }
    }
}