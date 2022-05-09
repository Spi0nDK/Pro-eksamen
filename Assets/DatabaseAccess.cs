/* Vi forsøgte at lave MongoDB som man også kan se i linje 13 er der et direkte link til vores MongoDB database.*/


/*using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseAccess : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://CastleRushers:LayDe1337@cluster0.u5fpt.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;

    void Start()
    {
        database = client.GetDatabase("Highscore");
        collection = database.GetCollection<BsonDocument>("HighscoreCollection");

        var document = new BsonDocument { { "username", 100 } };
        collection.InsertOne(document);

    }
}*/
