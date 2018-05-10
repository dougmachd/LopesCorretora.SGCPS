// Write your JavaScript code.

// Inicio JS Tela = PJ
// Botao adicionar/remover do cadastro de PJ para end. correspondencia
function EnderecoCorrespondencia(e) {
    var btn = document.getElementById("btnEnderecoCorrespondencia");
    if (e == "mais") {
        document.getElementById("EnderecoCorrespondencia").style.display = "";
        var funcaoMenos = "EnderecoCorrespondencia('menos')";
        btn.setAttribute('onclick', funcaoMenos);
        btn.setAttribute('class', 'glyphicon glyphicon-minus');
    } else {
        document.getElementById("EnderecoCorrespondencia").style.display = "none";
        var funcaoMais = "EnderecoCorrespondencia('mais')";
        btn.setAttribute('onclick', funcaoMais);
        btn.setAttribute('class', 'glyphicon glyphicon-plus');
    }
}

// Preenche os campos de endereco obtidos pelo cep na tela de cadastro de PJ
function GetCepPj(e) {
    $.ajax({
        type: "GET",
        url: 'https://viacep.com.br/ws/' + $("#CEP").val() + '/json/',
        data: "{}",
        cache: false,
        dataType: "html",
        assync: true,
        success: function (data) {
            var parsed = JSON.parse(data);
            if (parsed.erro != true) {
                if (e == "fiscal") {
                    document.getElementById("UF").value = parsed.uf;
                    document.getElementById("Rua").value = parsed.logradouro;
                    document.getElementById("Bairro").value = parsed.bairro;
                    document.getElementById("Cidade").value = parsed.localidade;
                } else {
                    document.getElementById("UFCorrespondencia").value = parsed.uf;
                    document.getElementById("RuaCorrespondencia").value = parsed.logradouro;
                    document.getElementById("BairroCorrespondencia").value = parsed.bairro;
                    document.getElementById("CidadeCorrespondencia").value = parsed.localidade;
                }
            } else {
                document.getElementById("UF").value = "";
                document.getElementById("Rua").value = "";
                document.getElementById("Bairro").value = "";
                document.getElementById("Cidade").value = "";
            }
        }
    })
}

// Adiciona campos necessarios para mais um plano na tela de cadastro PJ
function AcrescentarPlano(e) {

}
// Fim JS Tela = PJ

// Inicio JS Tela = PF
// Preenche os campos de endereco obtidos pelo cep na tela de cadastro de PF
function GetCepPf() {
    $.ajax({
        type: "GET",
        url: 'https://viacep.com.br/ws/' + $("#CEP").val() + '/json/',
        data: "{}",
        cache: false,
        dataType: "html",
        assync: true,
        success: function (data) {
            var parsed = JSON.parse(data);
            if (parsed.erro != true) {
                document.getElementById("UF").value = parsed.uf;
                document.getElementById("Rua").value = parsed.logradouro;
                document.getElementById("Bairro").value = parsed.bairro;
                document.getElementById("Cidade").value = parsed.localidade;
            } else {
                document.getElementById("UF").value = "";
                document.getElementById("Rua").value = "";
                document.getElementById("Bairro").value = "";
                document.getElementById("Cidade").value = "";
            }
        }
    })
}

function AdicionarDependente(id) {
    $("#form-dependente-1")
        .append("<div id='dependente_" + id + "'>" +
        "        <div class='col-xs-12 col-sm-12 col-md-12'> " +
        "            <h4> Dependente 1 </h4> <span style='cursor:pointer' id='btnRemoverDependente" + id + "' onclick='RemoverDependente(dependente_" + id + ")' class='glyphicon glyphicon-minus' /> " +
        "        </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-12 col-sm-12 col-md-12'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD_" + id + "__Nome'>Nome</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='NomeDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].Nome' placeholder='Nome.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD[" + id + "].Nome' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-4 col-sm-4 col-md-4'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD_" + id + "__CPF'>CPF</label> " +
        "                <input class='form-control' id='CPFDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].CPF' placeholder='CPF.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD[" + id + "].CPF' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-4 col-sm-4 col-md-4'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD_" + id + "__RG'>RG</label> " +
        "                <input class='form-control' id='RGDependente' name='LisDependentePessoaFisicaMOD[" + id + "].RG' placeholder='RG.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD[" + id + "].RG' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-2 col-sm-2 col-md-2'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "DataDeNascimento'>Data de nascimento</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='DataDeNascimentoDependente' name='LisDependentePessoaFisicaMOD[" + id + "].DataDeNascimento' placeholder='Data De Nascimento.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".DataDeNascimento' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-2 col-sm-2 col-md-2'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "GrauDeParentesco'>Grau de parentesco</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='GrauDeParentescoDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].GrauDeParentesco' placeholder='Grau De Parentesco.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".GrauDeParentesco' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-12 col-sm-12 col-md-12'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "NomeDaMae'>Nome da mae</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='NomeDaMaeDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].NomeDaMae' placeholder='Nome Da Mae.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".NomeDaMae' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-4 col-sm-4 col-md-4'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "EstadoCivil'>Estado civil</label> " +
        "                <select class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='EstadoCivilDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].EstadoCivil' required='required' size='1'><option value=''>Selecione</option> " +
        "                    <option value='casado'>Casado</option> " +
        "                    <option value='solteiro'>Solteiro</option> " +
        "                </select> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".EstadoCivil' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-8 col-sm-8 col-md-8'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "NumeroDoSUS'>Numero do SUS</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='NumeroDoSUSDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].NumeroDoSUS' placeholder='Numero Do SUS.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".NumeroDoSUS' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "</div>");
    SetProximoDependente(id);
}

function RemoverDependente(id) {
    var a = "dependente_" + id;
    var element = document.getElementById(a).value;
    element.innerHTML = "";
}

//function SetRemocao(id) {
//    var nome = "RemoverDependente(form-dependente-" + id + ")";
//    var mudar = document.getElementById('btnRemoverDependente');
//    mudar.setAttribute('onclick', nome);
//}

function SetProximoDependente(id) {
    var nome = "AdicionarDependente(" + id + ")";
    var mudar = document.getElementById('adicionarDependente');
    mudar.setAttribute('onclick', nome);
}


//alert de confirmacao de eclusao pessoa fisica
function ExcluirPJ() {
    bootbox.confirm({
        size: "small",
        message: "Deseja realmente excluir este cadastro?",
        callback: function (result) {
            /* result is a boolean; true = OK, false = Cancel*/
            if (result) {
                document.getElementById("AlterarPJ").submit();
            }
        }
    })
}