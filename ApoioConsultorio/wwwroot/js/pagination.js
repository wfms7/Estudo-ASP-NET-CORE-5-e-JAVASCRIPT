const totalProcedimento = document.getElementById('totalProcedimento').innerHTML;
const totalPaginacao = parseInt(totalProcedimento) / 10;
const navegacao = document.getElementById('navegacao');
const pagination = document.querySelector('[data-pagination]');
const url_string = window.location.href;
const url = new URLSearchParams(document.location.search)
const route = tratarRoute(url_string);
const urlSkip = url.get("skip");
const nameProcedimento = url.get("nameProcedimento");
const especial = url.get("especial");
const quantPagination = 5;

console.log(especial)



before(urlSkip)

paginacaoNumero();

next(urlSkip);

function tratarRoute(url) {

    let Separacao = url.split("/");

    console.log(Separacao)
  
    Separacao = Separacao[3].split("?");
    
  
   
    return Separacao;
}




   


function before(skip) {

    let result = (skip / 10) - 1;

    if (result < 0) {

        result = 0;
    }

    paginacao(result, "before");
}


function next(skip) {

    let result = (skip / 10) + 1;

    if (result < 0) {

        result = 0;
    }

    paginacao(result, "next");
}


function paginacaoNumero() {

    if (totalPaginacao > 1) {
        navegacao.hidden = false;
    }

    const valorFinal = ((parseInt(urlSkip) / 10)) + parseInt(quantPagination / 2)
    const valorInicial = ((parseInt(urlSkip) / 10)) - parseInt(quantPagination / 2);

    for (i = 0; i < parseInt(totalPaginacao + 1); i++) {





        if (urlSkip === "0" || urlSkip === "" || urlSkip ===null) {
            if (i < quantPagination)
                paginacao(i);
        }
        else if (urlSkip != "0") {

            if (i >= (valorInicial) && i <= valorFinal) {
                

                paginacao(i);
               
            }

        }



    }

}


function paginacao(pag, beforeNext) {



    const skip = (pag) * 10

    const novoLi = document.createElement('li')
    const novoA = document.createElement('a')
    novoA.classList.add("btn")
    if (parseInt(urlSkip) === skip) {
        novoA.classList.add("btn-info")

    } else {
        novoA.classList.add("btn-outline-info")
    }

    novoA.classList.add("mr-1")

    
    if (especial !== null && especial!=="null") {
        novoA.href = `${route[0]}?skip=${skip}&nameProcedimento=${nameProcedimento}&especial=${especial}`
    }
    else {
        novoA.href = `${route[0]}?skip=${skip}&nameProcedimento=${nameProcedimento}`
    }

    if (beforeNext === "before") {
        novoA.innerHTML = "<<<"
    } else if (beforeNext === "next") {
        novoA.innerHTML = ">>>"
    }
    else {
        novoA.innerHTML = pag + 1
    }

    novoLi.appendChild(novoA);
    pagination.innerHTML += novoLi.innerHTML;

}
