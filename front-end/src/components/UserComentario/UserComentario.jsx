import React from 'react'
import User from './UserName/User'
import LoadingDefault from '../loading/LoadingDefault'
import { api } from '../../lib/api'

function UserComentario() {
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
        // Pegar o tamanho da lista do banco de dados + 1 ou a data atual do momento sem formatação
        usuarioId: 8
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
    <div className="flex flex-col justify-center items-center">
      <header className="flex items-center py-4">
        <User />
      </header>
      <form onSubmit={handleSubmitPost} className="flex flex-col items-center">
        <textarea
          className="text-field p-8 outline-none border-none rounded-tr-[2rem] rounded-bl-[2rem] text-[1.8rem] resize-y"
          id=""
          cols="50"
          rows="10"
          onChange={event => setDescription(event.target.value)}
        ></textarea>

        <button
          type="submit"
          disabled={description.length === 0 || loading}
          className="bg-white py-4 px-4 mt-4 border-none outline-none text-[1.6rem] rounded-[2rem] cursor-pointer transition-all duration-300 hover:bg-black hover:text-white disabled:hover:cursor-not-allowed disabled:hover:bg-zinc-300 disabled:hover:text-zinc-100"
        >
          {loading ? <LoadingDefault /> : 'Enviar Postagem'}
        </button>
      </form>
    </div>
  )
}

export default UserComentario
