using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;

public class GameServer : MonoBehaviour
{

    private Dictionary<EndPoint, User> _dictionary;

    private EndPoint _senderRemote; 
    
    private Socket _socket;

    private byte[] _buffer;
    
    private byte[] _data2;
    private void Awake()
    {
        _senderRemote = new IPEndPoint(IPAddress.Any, 5000);
        _dictionary = new Dictionary<EndPoint, User>();
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        _buffer = new byte[1024];
        string message = "hello";
        _data2 = Encoding.ASCII.GetBytes(message);
        
        _socket.Bind(_senderRemote);

        Task.Run(() => Listen());


    }

    private void Listen()
    {
        Debug.Log("listening for connections");
        int received = _socket.ReceiveFrom(_buffer, ref _senderRemote);
            if (_dictionary.ContainsKey(_senderRemote))
            {
                Debug.Log("user already exists");
                if (_dictionary.TryGetValue(_senderRemote, out User user))
                {
                    user.lastSeen = DateTime.Now;
                }
            }
            Debug.Log("new user");
            string data = Encoding.ASCII.GetString(_buffer, 0, received);
            Debug.Log(data);
            _dictionary.Add(_senderRemote, new User());
            _socket.SendTo(_data2, _senderRemote); 
    }

  
}
