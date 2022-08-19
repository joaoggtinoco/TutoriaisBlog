import React from 'react'
import LoadingDefault from '../components/loading/LoadingDefault'
import { api } from '../lib/api'
import Header from '../components/Header'
import Footer from '../components/Footer'

function Blog() {
  const [description, setDescription] = React.useState('')
  const [loading, setLoading] = React.useState(false)

  async function handleSubmitPost(event) {
    event.preventDefault()

    console.log({
      description
    })
    setLoading(true)
    try {
      const response = await api.post('/api/Postagem', {
        conteudo: description,
        usuarioId: 3
        // Pegar o tamanho da lista do banco de dados + 1 ou a data atual do momento sem formatação
      })

      console.log('Enviado: ', response.data)
      setLoading(false)
      return
    } catch (e) {
      console.log('Deu erro: ', e)
      setLoading(false)
      return
    }
  }

  return (
    <>
      <Header />
      <div className="pt-[9.2rem] pb-7 px-[1rem]">
        <form
          onSubmit={handleSubmitPost}
          className="flex flex-col items-center justify-between bg-zinc-500 rounded-[8px] px-[1.57rem] py-[1.5rem] gap-[1.5rem]  w-full"
        >
          <h1 className="text-orange-300 font-bold text-[2.25rem] text-center">
            No que você está pensando hoje José ?{' '}
          </h1>
          <textarea
            className="text-field p-8 outline-none border-none rounded-[5px] text-[1.8rem] resize-none w-full bg-zinc-300 selection:bg-orange-300"
            cols="50"
            rows="15"
            onChange={event => setDescription(event.target.value)}
          ></textarea>

          <button
            type="submit"
            disabled={description.length === 0 || loading}
            className="text-white font-bold text-[2rem] py-5 px-3 bg-orange-300 flex justify-center w-auto sm:w-[35%] rounded-[5px] outline-none hover:bg-orange-500 focus:bg-orange-500 transition-colors disabled:opacity-50 disabled:cursor-not-allowed"
          >
            {loading ? <LoadingDefault /> : 'Enviar Postagem'}
          </button>
        </form>
      </div>
      {/* Uma lista de postagens antigas */}
      <Footer />
    </>
  )
}

export default Blog