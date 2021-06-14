using System;
using System.Threading;

    //it saves time as multiple task are executed at once
    /*PROPERTIES
     CurrentThread	-returns the instance of currently running thread.
    IsAlive	-checks whether the current thread is alive or not. It is used to find the execution status of the thread.
    IsBackground-	is used to get or set value whether current thread is in background or not.
    ManagedThreadId	-is used to get unique id for the current managed thread.
    Name	-is used to get or set the name of the current thread.
    Priority	-is used to get or set the priority of the current thread.
    ThreadState	-is used to return a value representing the thread state.

    METHOD
    Abort()-	is used to terminate the thread. It raises ThreadAbortException.
    Interrupt()-	is used to interrupt a thread which is in WaitSleepJoin state.
    Join()	-is used to block all the calling threads until this thread terminates.
    ResetAbort()-	is used to cancel the Abort request for the current thread.
    Resume()	-is used to resume the suspended thread. It is obselete.
    Sleep(Int32)-	is used to suspend the current thread for the specified milliseconds.
    Start()-	changes the current state of the thread to Runnable.
    Suspend()-	suspends the current thread if it is not suspended. It is obselete.
    Yield()	-is used to yield the execution of current thread to another thread.
    */



    public class Program2
    {
        //----------------------------------------
        //static methods
        //we call static or non static method on execution of threads
        //for this we create constructor
        //for static method dont create instance of class, ,just refer it by name of the class

        public static void Programs()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            //now go to main method of class Program
        }
    }

    //--------------------------------------------
    //for non static method
    public class Program3
    {
        public void Programes()
        {
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(i);
            }
            //now go to main method of class Program
        }
    }

//---------------------------------------------
//sleep() method
//The Sleep() method suspends the current thread for the specified milliseconds
public class Program4 
    {
        public void Programmeth()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
            //now go to main method of class Program
        }
    }
//---------------------------------------------
//Abort()
//is used to terminate the thread

//use class Program4
//-------------------------------------------
//Join()
//it calls all claiing threads to wait until current thread is terminated or it completes it task
//use class Program4

//-------------------------------------------------------------
//Name Thread
class Program5
{
    public void Myprogram5()
    {
        Thread tt = Thread.CurrentThread;
        Console.WriteLine( tt.Name);
    }
}

//------------------------------------------------------------------
//ThreadPriority
//chance of the high priority thread to execute before low priority thread.

//use class Program5
//------------------------------------------------------------------
//Thread Synchronization
//Synchronization is a technique that allows only one thread to access the resource for the particular time.
//No other thread can interrupt until the assigned thread finishes its task.

//C# Lock
//C# lock keyword to execute program synchronously.
//It is used to get lock for the current thread, execute the task and then release the lock

class Program6
{
    public void Method6()
    {
        lock (this)
        {
            for(int i=0; i < 8; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
                Console.WriteLine("thread synchronization");
            }
        }
    }
}
//------------------------------------------------------------------
class Program
    {
        static void Main()
        {
        
            Thread t = Thread.CurrentThread;
            //CurrentThread	-returns the instance of currently running thread.
            t.Name = "roshi";
            Console.WriteLine(t.Name);
        //----------------------------------------

        //static methods
        Thread t1 = new Thread(x => Console.WriteLine(x));
          //  Thread t1 = new Thread(new ThreadStart(Program2.Programs));
            Thread t2 = new Thread(new ThreadStart(Program2.Programs));
            t1.Start(1000);
            t2.Start();
        Console.WriteLine("static");

        //Start() - changes the current state of the thread to Runnable.
        /*output=0to 9 (2 times) */
        //----------------------------------------------

        //non static methods
        //instantiating Program class
        Program3 pp = new Program3();
       Thread tt1 = new Thread(new ThreadStart(pp.Programes));
         tt1.Start();
        Console.WriteLine("non static");

        //-------------------------------------------------
        //sleep()
        Program4 p = new Program4();
            Thread tp1 = new Thread(new ThreadStart(p.Programmeth));
            Thread tp2 = new Thread(new ThreadStart(p.Programmeth));
        tp1.Start();
        tp2.Start();
        Console.WriteLine("sleep");
        //-------------------------------------------------------------
        //abort()
        //using class Program4

        Program4 po = new Program4();
        Thread to1 = new Thread(new ThreadStart(po.Programmeth));
        Thread to2 = new Thread(new ThreadStart(po.Programmeth));
        to1.Start();
        to2.Start();

        try
        {
     //     to1.Abort();      //platform not supported exception
      //      to2.Abort();
        }
        catch(ThreadAbortException te)
        {
            Console.WriteLine(te.ToString());
        }
       
        Console.WriteLine("abort");

        //-------------------------------------------------------------
        //join
        //using class Program4
        Program4 pr = new Program4();
   Thread tr1 = new Thread(new ThreadStart(pr.Programmeth));
   Thread tr2 = new Thread(new ThreadStart(pr.Programmeth));
   tr1.Start();
   tr1.Join();
   tr2.Start();
   tr2.Join();
   Console.WriteLine("join");
        //-------------------------------------------------------------
        //Name Thread
        Program5 ps = new Program5();
        Thread ts1 = new Thread(new ThreadStart(ps.Myprogram5));
        Thread ts2 = new Thread(new ThreadStart(ps.Myprogram5));
        Thread ts3 = new Thread(new ThreadStart(ps.Myprogram5));
        ts1.Name = "payal";
        ts2.Name = "sahil";
        ts3.Name = "goel";


        ts1.Start();
        ts2.Start();
        ts3.Start();
        Console.WriteLine("name thread");
        //------------------------------------------------------------------
        //ThreadPriority
   //    ts1.Priority = ThreadPriority.Highest;
     //  ts2.Priority = ThreadPriority.Normal;
     //   ts3.Priority = ThreadPriority.Lowest;

     //  ts1.Start();
      //  ts2.Start();
        //ts3.Start();
        Console.WriteLine("thread priority");
        //------------------------------------------------------------------
        //Thread Synchronization
        Program6 py = new Program6();
        Thread ty1 = new Thread(new ThreadStart(py.Method6));
        Thread ty2 = new Thread(new ThreadStart(py.Method6));
        ty1.Start();
        ty2.Start();
    }
}
