using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMessage
{
    void CreateNewMessage(int messagesCount);
    void DeleteMessage(int messageNumber);
}
