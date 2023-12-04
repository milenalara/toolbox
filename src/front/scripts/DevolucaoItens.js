function exibirMensagem(modal) {
  document.getElementById("modal").style.display = "flex";
  document.getElementById("mensagem").innerHTML = modal;
}

function fecharModal() {
  document.getElementById("modal").style.display = "none";
}
var id= localStorage.getItem("idUsuario")
function carregarProdutos() {
  // Fazer requisição GET para obter os produtos
  fetch('https://localhost:7146/api/DevolucaoDeItens/'+id)
      .then(response => response.json())
      .then(produtos => {
          const tabela = document.getElementById('tabela');
          if(!produtos)
              return false
          // Iterar sobre cada produto retornado
          produtos.forEach(produto => {
              // Criar uma nova linha na tabela para o produto
              const linha = document.createElement('tr');

              // Criar as células para cada campo do produto (nome, devolução, ação)
              const nomeCelula = document.createElement('td');
              nomeCelula.classList.add('w-25');
              nomeCelula.textContent = produto.nome;
              linha.appendChild(nomeCelula);

              const statusCelula = document.createElement('td');
              statusCelula.classList.add('w-25');
              statusCelula.textContent = produto.status;
              linha.appendChild(statusCelula);

              const inicioCelula = document.createElement('td');
              inicioCelula.classList.add('w-25');
              inicioCelula.textContent = produto.data_inicio;
              linha.appendChild(inicioCelula);

              const devolucaoCelula = document.createElement('td');
              devolucaoCelula.classList.add('w-75');
              devolucaoCelula.textContent = produto.data_fim;
              linha.appendChild(devolucaoCelula);

              const acaoCelula = document.createElement('td');
              nomeCelula.classList.add('w-25');
              const botaoDevolucao = document.createElement('button');
              botaoDevolucao.textContent = 'Devolver';
              botaoDevolucao.addEventListener('click', () => devolverProduto(produto.id));
              acaoCelula.appendChild(botaoDevolucao);
              linha.appendChild(acaoCelula);

              // Adicionar a linha à tabela
              tabela.appendChild(linha);
          });
      })
      .catch(error => {
          exibirMensagem("Ocorreu um erro na requisição: " + error)
      });
}

// Function to call the API and perform the return
function performReturn(productId) {
  fetch(`https://example.com/api/returns/${productId}`, {
    method: 'POST',
  })
    .then(response => {
      if (response.ok) {
        exibirMensagem("Devolução solicitada!")
      } else {
        exibirMensagem("Erro ao realizar a devolução.")
      }
    })
    .catch(error => {
      console.error('Error:', error);
      exibirMensagem("Erro ao realizar a devolução: " + error)
    });
}

function inicia(){
  if(carregarProdutos() == false)
    exibirMensagem("Você não tem nenhum produto alugado")
}

// Call the function to populate the table on page load
window.addEventListener('DOMContentLoaded', inicia);

