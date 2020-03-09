const mongoose = require("mongoose");
const Cryptr = require('cryptr');
const cryptr = new Cryptr('myTotalySecretKey');
const fs = require('fs');


const Cliente = require("../Models/Cliente");

module.exports.obterClientes = (res) => {
    Cliente.find()
        .exec()
        .then(results => {
            res.status(200).json({
                count: results.length,
                clientes: results.map(result => {
                    return {
                        _id: result._id,
                        nome: result.nome,
                        morada: result.morada,
                        telemovel: result.telemovel,
                        email: result.email,
                        password: result.password
                    };
                })
            });
        })
        .catch(err => {
            res.status(500).json({
                error: "Error"
            });
        });
}

module.exports.obterClienteMail = (req, res) => {
    Cliente.find({ email: req.body.email }, function (err, cliente) {

        if (err) {
            console.log(err);
            return
        }

        //console.log(cliente[0].email);

        var id = cliente[0]._id;

        Cliente.findById(id, function (err, cliente) {
            if (err)
                res.send(err);

            res.json(cliente);
        });
    })
}

module.exports.autenticate = (req, res) => {
    Cliente.find({ email: req.body.email }, function (err, cliente) {
        if (err) {
            res.status(500).json({
                error: "Error"
            });
            return
        }
        console.log(cliente.length);
        if (cliente.length !== 0) { //existe cliente
            console.log(req.body.password);
            console.log("-----------------------------------------------------------------------------------------------")
            console.log(cryptr.decrypt(cliente[0].password));
            if (req.body.password == cryptr.decrypt(cliente[0].password)) {
                res.status(200).json({
                    out: 1
                });
            } else {
                res.status(500).json({
                    out: 2
                });
            }
        } else {
            res.status(500).json({
                out: 3
            });
        }

    })
}

module.exports.criarCliente = (req, res) => {
    Cliente.find({ email: req.body.email }, function (err, data) {
        if (err) {
            console.log(err);
            return
        }
        if (data.length == 0) {
            var pass = cryptr.encrypt(req.body.password);
            var cliente = new Cliente({
                nome: req.body.nome,
                morada: req.body.morada,
                telemovel: req.body.telemovel,
                email: req.body.email,
                password: pass
            });
            return cliente.save()
                .then(result => {
                    console.log(result);
                    res.status(201).json({
                        message: "Cliente criado com sucesso!",
                        clienteCriado: {
                            _id: result._id,
                            nome: result.nome,
                            morada: result.morada,
                            telemovel: result.telemovel,
                            email: result.email,
                            password: result.password
                        },
                    });
                })
                .catch(err => {
                    console.log(err);
                    res.status(500).json({
                        error: "Error"
                    });
                });
        } else {
            console.log(data[0].name);
            res.status(500).json({
                error: "Error, email já utilizado!"
            });
        }
    })
}

module.exports.alterarCliente = (req, res) => {
    Cliente.find({ email: req.body.email }, function (err, cliente) {

        if (err) {
            console.log(err);
            return
        }

        console.log(cliente[0]._id);

        var id = cliente[0]._id;
        var flag = 0;

        //verifica se ja existe algum mail na base dados com o mesmo nome que o que o utilizador pretende alterar
        Cliente.find({ email: req.body.email1 }, function (err, cliente1) {
            console.log("oioioioioioi")
            console.log(cliente1.length)
            console.log(flag)
            if (cliente1.length > 0) {
                res.status(500).json({
                    error: "Error, email já utilizado!"
                });

            } else {
                Cliente.findById(id, function (err, cliente) {
                    if (err)
                        res.send(err);

                    // update the client info
                    cliente.nome = req.body.nome;
                    cliente.morada = req.body.morada,
                        cliente.telemovel = req.body.telemovel,
                        cliente.email = req.body.email1,
                        cliente.password = cryptr.encrypt(req.body.password)

                    // save the cliente
                    cliente.save(function (err) {
                        if (err)
                            res.send(err);

                        res.json({ message: 'Client updated!' });
                    });
                });
            }
        });
    })


}
module.exports.alterarClienteAdmin = (req, res) => {
    Cliente.find({ email: req.body.email }, function (err, cliente) {
        console.log("Tamanho: " + cliente.length);

        if (cliente.length !== 0) {

            console.log(cliente[0]._id);

            var id = cliente[0]._id;

            Cliente.findById(id, function (err, cliente) {
                if (err)
                    res.send(err);

                // update the client info
                cliente.nome = req.body.nome;
                cliente.morada = req.body.morada,
                    cliente.telemovel = req.body.telemovel,


                    // save the cliente
                    cliente.save(function (err) {
                        if (err)
                            res.send(err);

                        res.json({ message: 'Client updated!' });
                    });
            });

        } else {
            res.status(500).json({
                error: "Email inexistente!"
            });
        }
    })
}

module.exports.deleteClienteByEmail = (req, res) => {
    Cliente.find({ email: req.body.email }, function (err, cliente) {
        console.log("Tamanho: " + cliente.length);

        if (cliente.length !== 0) {

            console.log(cliente[0]._id);

            var id = cliente[0]._id;

            Cliente.findById(id, function (err, cliente) {
                if (err)
                    res.send(err);

                console.log("VAI");
                // save the cliente
                cliente.delete(function (err) {
                    if (err)
                        res.send(err);

                    res.json({ message: 'Client deleted!' });
                });
            });

        } else {
            res.status(500).json({
                error: "Email inexistente!"
            });
        }
    });
}

module.exports.alterarPermissao = (req, res) => {
    var data = req.body.permissao;

    fs.writeFile('PermissaoClientes.txt', data, (err) => {
        res.send("succeso");
        // In case of a error throw err. 
        if (err) throw err;
    })
}

module.exports.getPermissao = (req, res) => {
    var content;
    fs.readFile('PermissaoClientes.txt', function read(err, data) {
        if (err) {
            throw err;
        }
        content = data;
        console.log(content);
        res.send(content);
    });

}

module.exports.alterarPermissaoCliente = (req, res) => {
    var data = req.body.permissao;

    fs.writeFile('PermissaoClientes2.txt', data, (err) => {
        res.send("succeso");
        // In case of a error throw err. 
        if (err) throw err;
    })
}

module.exports.getPermissaoCliente = (req, res) => {
    var content;
    fs.readFile('PermissaoClientes2.txt', function read(err, data) {
        if (err) {
            throw err;
        }
        content = data;
        console.log(content);
        res.send(content);
    });

}
