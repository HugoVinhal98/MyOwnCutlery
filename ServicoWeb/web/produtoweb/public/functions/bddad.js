
const HttpGetMaquinas = new XMLHttpRequest();
const urlGetMaquinas = 'https://localhost:5003/api/maquina';
HttpGetMaquinas.open("GET", urlGetMaquinas);
HttpGetMaquinas.send();

const HttpGetLinhas = new XMLHttpRequest();
const urlGetLinhas = 'https://localhost:5003/api/linhaproducao';
HttpGetLinhas.open("GET", urlGetLinhas);
HttpGetLinhas.send();

const HttpGetLinhasMaquinas = new XMLHttpRequest();
const urlGetLinhasMaquinas = 'https://localhost:5003/api/linhaproducaoMaquina';
HttpGetLinhasMaquinas.open("GET", urlGetLinhasMaquinas);
HttpGetLinhasMaquinas.send();


const urlGetDescricao = 'https://localhost:5003/api/maquina/byid/';


var HttpClient = function () {
    this.get = function (aUrl, aCallback) {
        var anHttpRequest = new XMLHttpRequest();
        anHttpRequest.onreadystatechange = function () {
            if (anHttpRequest.readyState == 4 && anHttpRequest.status == 200)
                aCallback(anHttpRequest.responseText);
        }

        anHttpRequest.open("GET", aUrl, true);
        anHttpRequest.send(null);
    }
}

HttpGetMaquinas.onreadystatechange = (e) => {
    var resposta = HttpGetMaquinas.responseText;
    var array = JSON.parse(resposta);

    nrMaquinas = array.length;
    console.log("Nr maquinas: " + nrMaquinas);
}

HttpGetLinhas.onreadystatechange = (e) => {
    var resposta = HttpGetLinhas.responseText;
    var array = JSON.parse(resposta);

    nrLinhas = array.length;
    //console.log(" Nr linhas: " + nrLinhas + "\n Linhas: \n" + JSON.stringify(array));
    var i;
    for (i = 0; i < nrLinhas; i++) {
        linhasMaquinas[i][0] = array[i].id;
    }
    //console.log("linhas: " + JSON.stringify(linhasMaquinas));
}

HttpGetLinhasMaquinas.onreadystatechange = (e) => {
    var resposta = HttpGetLinhasMaquinas.responseText;
    var array = JSON.parse(resposta);
    var nrLinhasMaquinas = array.length;
    //console.log("nr de linhas maquinas: " + nrLinhasMaquinas);
    linhasMaquinas2 = JSON.stringify(array);
    //console.log("Linhas e maquinas: " + linhasMaquinas2);

    var i, j, k;
    for (i = 0; i < nrLinhasMaquinas; i++) {
        var linhaAtual = array[i].idLinhaProducao;
       // console.log("Atual: " + linhaAtual);
        for (j = 0; j < 6; j++) {
            if (linhasMaquinas[j][0] == linhaAtual) {
                //console.log(linhasMaquinas[j][0]);
                for (k = 1; k < 6; k++) {
                    if (linhasMaquinas[j][k] == array[i].idMaquina) {
                        break;
                    }
                    if (linhasMaquinas[j][k] == null) {
                        //console.log(linhasMaquinas[j][k] + ",k:" + k + "," + array[i].idMaquina)
                        linhasMaquinas[j][k] = array[i].idMaquina;
                        //console.log("maquina: " + linhasMaquinas[j][k]);
                        break;
                    }
                }
                break;
            }
        }
    }
    //console.log("lista final:\n" + JSON.stringify(linhasMaquinas));
    for (let x = 0; x < nrLinhas; x++) {
        // desenha linha x
        for (let y = 1; y < 6; y++) {
            if (typeof linhasMaquinas[x][y] !== 'undefined') {
                //var HttpGetDescricao = new XMLHttpRequest();
                //console.log("maquina a encontrar: " + linhasMaquinas[x][y] + " " + x + " " + y);
                var urlDesc = urlGetDescricao + linhasMaquinas[x][y];
                //console.log(urlDesc);
                var client = new HttpClient();
                client.get(urlDesc, function (response) {
                    // desenha maquina y
                    //console.log("linha" + (x + 1) + " " + response);
                    linhasMaquinas[x][y] = response;
                    /* console.log("linhamaquina" + (x + 1) + " " + linhasMaquinas[x][y]); */
                    if (x == nrLinhas - 2 && typeof linhasMaquinas[x][y + 1] == 'undefined') {
                        flag = true;
                        // console.log("FLAG: " + flag);
                        // console.log("POSICAO: " + x);
                    }
                });

            } else {
                break;
            }
        }
    }
    // console.log("END");
    // console.log("fim:" + JSON.stringify(linhasMaquinas));
    //criarDescricoes();
}



