using PriorityQueueSample;

class Program
{
    public static void Main(string[] args)
    {
        //Ordinary Priority queue
        var patiants = new List<(Patient, int)>()
        {
             (new ("item1",23),2),
             (new ("item2",23),2),
             (new ("item3",23),2),
             (new ("item4",23),1),
        };

        var hospital = new PriorityQueue<Patient, int>(patiants);

        hospital.Enqueue(new Patient("item5", 24), 3);

        var findPeekItem = hospital.Peek();

        Console.WriteLine("Peek Item: " + findPeekItem.Name + " " + findPeekItem.Age);

        while (hospital.Count > 0)
        {
            Console.WriteLine(hospital.Dequeue().Name);
        }

        //Comparer Priority queue
        var patients = new List<Patient>()
        {
            new("Sarah", 23),
            new("Joe", 50),
            new("Elizabeth", 60),
            new("Natalie", 16),
            new("Angie", 25),
        };

        var comparar = new PriorityQueue<Patient, Patient>(new HospitalQueueComparer());

        patients.ForEach(p => comparar.Enqueue(p, p));

        var dequeueItem=comparar.Dequeue();

        Console.WriteLine("Dequeued Item "+ dequeueItem.Name+" "+ dequeueItem.Age);

    }
}