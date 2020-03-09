const express = require("express");
const app = express();
const morgan = require("morgan");
const mongoose = require("mongoose");
const bodyParser = require('body-parser');

const ClientesRoutes = require("./Routes/Clientes");
const EncomendasRoutes = require("./Routes/Encomendas");

var MongoClient = require('mongodb').MongoClient;
var url = "mongodb://localhost:27017/";

MongoClient.connect(url, function (err, db) {
    if (err) throw err;
    var dbo = db.db("GE_Database_Mock");
    dbo.collection("clientes").drop(function (err, delOK) {
        if (err) throw err;
        if (delOK) console.log("Collection deleted");
        db.close();
    });
    dbo.collection("encomendas").drop(function (err, delOK) {
        if (err) throw err;
        if (delOK) console.log("Collection deleted");
        db.close();
    });
});

mongoose.connect('mongodb://localhost/GE_Database_Mock');
var db = mongoose.connection;
db.on('error', console.error.bind(console, 'Connection error:'));
db.once('open', function () {
    console.log("Mongoose database connection was successful!");
});
mongoose.Promise = global.Promise;

// Mock Inserter

var doc = {
    nome: "Cliente Mock",
    morada: "Rua Mock",
    telemovel: 912345643,
    email: "clientemock@gmail.com",
    password: "password",
}

db.collection("clientes").insertOne(doc, function (err, res) {
    if (err) throw err;
    console.log("Document inserted");
});

var doc2 = {
    nrEncomenda: 21261806,
    estado: "Criada",
    clienteEmail: "clientemock@gmail.com",
    produto: "Colher",
    quantidade: 1000
}

db.collection("encomendas").insertOne(doc2, function (err, res) {
    if (err) throw err;
    console.log("Document inserted");
});

app.use(morgan("dev"));
app.use('/uploads', express.static('uploads'));
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.use((req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*");
    res.header(
        "Access-Control-Allow-Headers",
        "Origin, X-Requested-With, Content-Type, Accept"
    );
    if (req.method === "OPTIONS") {
        res.header("Access-Control-Allow-Methods", "PUT, POST, PATCH, DELETE, GET");
        return res.status(200).json({});
    }
    next();
});

// Routes which should handle requests
app.use("/api/Clientes", ClientesRoutes);
app.use("/api/Encomendas", EncomendasRoutes);

app.use((req, res, next) => {
    const error = new Error("Not found");
    error.status = 404;
    next(error);
});

app.use((error, req, res, next) => {
    res.status(error.status || 500);
    res.json({
        error: {
            message: error.message
        }
    });
});

module.exports = app;