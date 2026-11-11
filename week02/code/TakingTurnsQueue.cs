/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added
/// to the back of the queue (FIFO). When GetNextPerson is called, the next
/// person is returned and placed back into the queue if they have turns remaining.
/// A turns value of 0 or less means the person stays in the queue forever.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person and re-enqueue them if they have turns remaining
    /// or have infinite turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Zero or negative turns mean infinite turns.
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Reduce the remaining turns and re-enqueue.
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}