﻿using System;

namespace Maybe
{
    public abstract class Maybe<T>
    {
        internal Maybe() { }

        public static Maybe<T> CreateSuccess(T value)
        {
            return new Success<T>(value);
        }

        public static Failure<T> CreateFailure()
        {
            return new Failure<T>();
        }
    }

    public class Success<T> : Maybe<T>
    {
        internal Success(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public class Failure<T> : Maybe<T>
    {
        internal Failure() { }
    }
}
