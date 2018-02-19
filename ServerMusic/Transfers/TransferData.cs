﻿using System.IO;
using System;
using System.Text;
using System.Xml.Serialization;

namespace ServerMusic.Transfers
{
    public class TransferData
    {
        public Song Song { get; set; }
        public Command Command { get; set; }

        public TransferData(Song _song, Command _command)
        {
            Song = _song;
            Command = _command;
        }

        public TransferData()
        {

        }

        public static string ConvertToXML(TransferData data)
        {
            XmlSerializer songSerializer = new XmlSerializer(typeof(TransferData));

            using (var stream = new MemoryStream())
            {
                songSerializer.Serialize(stream, data);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }

        public static TransferData ConvertToTransferData(string convertableString)
        {
            Byte[] receiveBytes = Encoding.UTF8.GetBytes(convertableString);

            XmlSerializer formatter = new XmlSerializer(typeof(TransferData));

            using (var stream = new MemoryStream())
            {
                stream.Write(receiveBytes, 0, receiveBytes.Length);
                stream.Position = 0;
                TransferData transferData = (TransferData)formatter.Deserialize(stream);
                return transferData;
            }
        }
    }
}
