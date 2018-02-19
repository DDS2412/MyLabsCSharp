using System.Collections.Generic;

namespace AlternativeLabaCS1.Commands
{
    interface ICommandBehavior
    {
        List<Song> DoSomeCommand(List<Song> songs);
    }
}
