# Encrypted-Messaging-Platform

This project was submitted as coursework in the first semester in my third year of university. During the development of this process the crystal clear methodology was used in order to ensure quick delivery to the client.

The platform consists of two applications, a server and a client application.

The server application is meant to be run on a central server in the premises of the client's company. The clients then use their credentials and after they have been verified, they can connect to the server.

All messages between clients are encrypted using AES and each user has a unque key which is store, encypted in a remote database.

All messages are stored in the database for a 6 month period, after which messages that were not marked as important are deleted, using a script on the server (This was done using a server script because the university database did not allow the use of SQl server agents).
