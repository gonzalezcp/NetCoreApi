using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DependencyInjection
{
    public interface IDependentClass
    {
        void DoSomethingInDependentClass();
    }

    public interface IInjectDependent
    {
        void InjectDependent(IDependentClass dependentClass);
    }

    public class MainClass : IInjectDependent
    {
        IDependentClass dependentClass;

        public void DoSomething()
        {
            dependentClass.DoSomethingInDependentClass();
        }

        #region IInjectDependent Members

        public void InjectDependent(IDependentClass dependentClass)
        {
            this.dependentClass = dependentClass;
        }

        #endregion
    }

    public class DependentClass1 : IDependentClass
    {
        public void DoSomethingInDependentClass()
        {
            Console.WriteLine("Hello from DependentClass1: I can be injected into MainClass");
        }
    }

    public class DependentClass2 : IDependentClass
    {
        public void DoSomethingInDependentClass()
        {
            Console.WriteLine("Hello from DependentClass2: I can be injected as well, just change App.Config");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get the correct dependency based on configuration file
            IDependentClass dependency = GetCorrectDependency();

            // Create our main class and inject the dependency
            MainClass mainClass = new MainClass();
            ((IInjectDependent)mainClass).InjectDependent(dependency);

            // Use the main class, the method references the dependency
            // so behaviour depends on the configuration file
            mainClass.DoSomething();

            Console.ReadLine();
        }

        /// <summary>
        /// Instantiate and return a class conforming to the IDependentClass interface:
        /// which class gets instantiated depends on the ClassName setting in
        /// the configuration file
        /// </summary>
        /// <returns>Class conforming to the IDependentClass interface</returns>
        static IDependentClass GetCorrectDependency()
        {
            string classToCreate = System.Configuration.ConfigurationManager.AppSettings["ClassName"];
            Type type = System.Type.GetType(classToCreate);
            IDependentClass dependency = (IDependentClass)Activator.CreateInstance(type);
            return dependency;
        }
    }
}
