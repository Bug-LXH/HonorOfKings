using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public static class NetManager
{
    private static Socket _socket;

    private static void init()
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public static void connect(string ip, int port)
    {
        init();
        _socket.BeginConnect(ip, port, connectCallBack, _socket);
    }

    private static void connectCallBack(IAsyncResult ar)
    {
        try
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndConnect(ar);
            Debug.Log("联接成功");
            
            //接收消息
            //socket.BeginReceive();
        }
        catch (SocketException e)
        {
            Debug.LogError(e.Message);
            throw;
        }
    }
    
}
