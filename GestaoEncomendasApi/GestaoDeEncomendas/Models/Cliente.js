var mongoose = require('mongoose');
var Email = require("../ValueObjects/Email");
var Password = require("../ValueObjects/Password");
var Nome = require("../ValueObjects/Nome");
var Telemovel = require("../ValueObjects/Telemovel");
var Morada = require("../ValueObjects/Morada");
var Schema = mongoose.Schema;

var ClienteSchema = new Schema({
  nome: Nome,
  morada: Morada,
  telemovel: Telemovel,
  email: Email,
  password: Password
});

module.exports = mongoose.model('Cliente', ClienteSchema);