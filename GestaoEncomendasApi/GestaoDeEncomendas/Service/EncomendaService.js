const mongoose = require("mongoose");

const Encomenda = require("../Models/Encomenda");
const ProdutoEncomendado = require("../Models/ProdutoEncomendado");

module.exports.getAllEncomendas = (req, res, next) => {
    Encomenda.find()
        .exec()
        .then(docs => {
            res.status(200).json({
                count: docs.length,
                encomendas: docs.map(doc => {
                    return {
                        nrEncomenda: doc.nrEncomenda,
                        dataEnvio: doc.dataEnvio,
                        dataEntrega: doc.dataEntrega,
                        estado: doc.estado,
                        clienteEmail: doc.clienteEmail,
                        cancelamentoCliente: doc.cancelamentoCliente,
                        solicitacaoCliente: doc.solicitacaoCliente,
                        quantidade: doc.quantidade,
                        produto: doc.produto
                    };
                })
            });
        })
        .catch(err => {
            res.status(500).json({
                error: "Error"
            });
        });
};

module.exports.getQuantidadeEncomendas = (req, res, next) => {
    Encomenda.find()
        .exec()
        .then(docs => {
            res.status(200).json({
                count: docs.length,
                encomendas: docs.map(doc => {
                    return {
                        quantidade: doc.quantidade,
                        produto: doc.produto
                    };
                })
            });
        })
        .catch(err => {
            res.status(500).json({
                error: "Error"
            });
        });
};

module.exports.getEncomendaByID = (req, res, next) => {
    Encomenda.find({ nrEncomenda: req.body.nrEncomenda }, function (err, encomenda) {

        if (err) {
            console.log(err);
            return
        }

        var id = encomenda[0]._id;

        Encomenda.findById(id, function (err, encomenda) {
            if (err)
                res.send(err);

            res.json(encomenda);
        });
    })
};

module.exports.getAllEncomendasUser = (req, res, next) => {
    Encomenda.find({ clienteEmail: req.body.clienteEmail })
        .exec()
        .then(docs => {
            res.status(200).json({
                count: docs.length,
                encomendas: docs.map(doc => {
                    return {
                        nrEncomenda: doc.nrEncomenda,
                        dataEnvio: doc.dataEnvio,
                        dataEntrega: doc.dataEntrega,
                        estado: doc.estado,
                        cliente: doc.cliente,
                        quantidade: doc.quantidade,
                        produto: doc.produto
                    };
                })
            });
        })
        .catch(err => {
            res.status(500).json({
                error: "Error"
            });
        });
};


module.exports.postEncomenda = (req, res, next) => {

    var ID = Math.floor(Math.random() * (Math.floor(99999999) - Math.ceil(10000000))) + Math.ceil(10000000);

    var encomenda = new Encomenda({
        dataEnvio: null,
        dataEntrega: null, //req.body.dataEntrega,
        nrEncomenda: ID,
        estado: 'Criada',
        cancelamentoCliente: 'Sem solicitação de cancelamento',
        solicitacaoCliente: 'Sem solicitação de alterações',
        clienteEmail: req.body.clienteEmail,
        produto: req.body.produto,
        quantidade: req.body.quantidade
    });

    return encomenda.save()
        .then(result => {
            console.log(result);
            res.status(201).json({
                message: "Encomenda criada com sucesso!",
                encomendaCriada: {
                    _id: result._id,
                    nrEncomenda: result.nrEncomenda,
                    //dataEnvio: result.dataEnvio,
                    //dataEntrega: result.dataEntrega,
                    estado: result.estado,
                    cliente: result.clienteEmail,
                    quantidade: result.quantidade,
                    produto: result.produto
                },
            });
        })
        .catch(err => {
            console.log(err);
            res.status(500).json({
                error: "Error"
            });
        });
};

module.exports.cancelarEncomenda = (req, res, next) => {
    Encomenda.find({ nrEncomenda: req.body.nrEncomenda }, function (err, encomenda) {

        if (err) {
            console.log(err);
            return
        }

        var id = encomenda[0]._id;

        Encomenda.findById(id, function (err, encomenda) {
            if (err)
                res.send(err);

            // cancela encomenda
            encomenda.estado = 'Cancelada';

            // save the encomenda
            encomenda.save(function (err) {
                if (err)
                    res.send(err);

                res.json({ message: 'Encomenda Cancelada' });
            });
        });

    });
};

module.exports.alterarEncomenda = (req, res) => {
    Encomenda.find({ nrEncomenda: req.body.nrEncomenda }, function (err, encomenda) {

        if (err) {
            console.log(err);
            return
        }

        var id = encomenda[0]._id;

        Encomenda.findById(id, function (err, encomenda) {
            if (err)
                res.send(err);

            encomenda.quantidade = req.body.quantidade;
            encomenda.produto = req.body.produto.nome;
            encomenda.dataEnvio = req.body.dataEnvio;
            encomenda.dataEntrega = req.body.dataEntrega;

            encomenda.save(function (err) {
                if (err)
                    res.send(err);

                res.json({ message: 'Encomenda Alterada com Sucesso' });
            });
        });
    })
};

module.exports.produtosEncomendados = (req, res, next) => {
    Encomenda.find()
        .exec()
        .then(docs => {
            res.status(200).json({
                count: docs.length,
                encomendas: docs.map(doc => {
                    return {
                        nrEncomenda: doc.nrEncomenda,
                        dataEnvio: doc.dataEnvio,
                        dataEntrega: doc.dataEntrega,
                        estado: doc.estado,
                        clienteEmail: doc.clienteEmail,
                        quantidade: doc.quantidade,
                        produto: doc.produto
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

module.exports.solicitarCancelamentoEncomenda = (req, res) => {
    Encomenda.find({ nrEncomenda: req.body.nrEncomenda }, function (err, encomenda) {

        if (err) {
            console.log(err);
            return
        }

        var id = encomenda[0]._id;

        Encomenda.findById(id, function (err, encomenda) {
            if (err)
                res.send(err);

            // solicita cancelamento de encomenda
            encomenda.cancelamentoCliente = 'Cancelamento solicitado';

            // save the encomenda
            encomenda.save(function (err) {
                if (err)
                    res.send(err);

                res.json({ message: 'Soliticação de cancelamento realizada com sucesso!' });
            });
        });

    });

};

module.exports.solicitarAlteracoesEncomenda = (req, res) => {
    Encomenda.find({ nrEncomenda: req.body.nrEncomenda }, function (err, encomenda) {

        if (err) {
            console.log(err);
            return
        }

        var id = encomenda[0]._id;

        Encomenda.findById(id, function (err, encomenda) {
            if (err)
                res.send(err);

            // solicita alteracao de encomenda
            encomenda.solicitacaoCliente = req.body.solicitacaoCliente;

            // save the encomenda
            encomenda.save(function (err) {
                if (err)
                    res.send(err);

                res.json({ message: 'Soliticação de alteração realizada com sucesso!' });
            });
        });

    });

};