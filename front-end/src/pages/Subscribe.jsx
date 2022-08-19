import Header from '../components/Header'
import Logo from '../assets/LogoNomeLongo.svg'
import Footer from '../components/Footer'
import LoadingDeafult from '../components/loading/LoadingDefault'

import { Eye, EyeClosed } from 'phosphor-react'

import React from 'react'

import { useNavigate } from 'react-router-dom'

export default function Subscribe({ type }) {
  const navigate = useNavigate()

  const [loading, setLoading] = React.useState(false)
  const [eye, setEye] = React.useState(false)
  const [email, setEmail] = React.useState('')
  const [password, setPassword] = React.useState('')
  const [name, setName] = React.useState('')

  function handleLoginUser(event) {
    event.preventDefault()
    setLoading(true)
    // Função de req e res
    console.log({
      email,
      password
    })

    setLoading(false)
    // Manda pra pagina caso o usuario exista
    navigate('/blog')
  }

  function handleCreateUser(event) {
    event.preventDefault()
    setLoading(true)
    // Função de req e res
    console.log({
      email,
      password,
      name
    })

    setLoading(false)
    // Manda pra pagina caso o usuario exista
    navigate('/blog')
  }

  return (
    <>
      <Header type="default" />
      {type === 'login' ? (
        <div className="flex flex-col items-center gap-[1.313rem] pt-[9.2rem] pb-7 px-6">
          <img src={Logo} alt="logo" />
          <form
            onSubmit={handleLoginUser}
            className="flex flex-col items-center gap-[8.5rem] bg-zinc-500 rounded-[8px] p-5 w-full lg:max-w-[72.5rem]"
          >
            <div className="flex flex-col w-full items-center gap-5">
              <label
                for="Email"
                className="text-orange-300 font-bold text-[2.25rem]"
              >
                Email
              </label>
              <input
                type="email"
                id="Email"
                name="Email"
                placeholder="Digite o seu Email"
                onChange={event => setEmail(event.target.value)}
                className="bg-zinc-300 rounded-[5px] px-5 h-20 w-full lg:max-w-lg placeholder-black placeholder:text-[15px] 
              text-[15px] outline-0
              focus:outline-none focus:border focus:ring-green-300 focus:border-green-300 hover:border-green-300 hover:border invalid:text-red-500 focus:invalid:border-red-500 transition-all duration-500 ease-in-out"
                required
              />

              <label
                for="Password"
                className="text-orange-300 font-bold text-[2.25rem]"
              >
                Senha
              </label>
              <div className="flex flex-col w-full items-center gap-5 relative">
                <input
                  type={eye ? 'text' : 'password'}
                  id="Password"
                  name="Password"
                  placeholder="Digite sua senha no mínimo 8 dígitos"
                  onChange={event => setPassword(event.target.value)}
                  className={`bg-zinc-300 rounded-[5px] px-5 h-20 w-full lg:max-w-lg placeholder-black placeholder:text-[15px] text-[15px] outline-0
              focus:outline-none focus:border focus:ring-green-300 focus:border-green-300 hover:border-green-300 hover:border invalid:text-red-500 focus:invalid:border-red-500 ${
                password.length < 8 ? 'focus:border-red-500 text-red-500' : ''
              } transition-all duration-500 ease-in-out`}
                  required
                />
                <button
                  className="absolute top-0 bottom-0 right-0 lg:right-80 pr-3 lg:pr-0 cursor-pointer"
                  onClick={event => {
                    event.preventDefault()
                    eye ? setEye(false) : setEye(true)
                  }}
                >
                  {eye ? <Eye size={30} /> : <EyeClosed size={30} />}
                </button>
              </div>
              <button
                className="text-orange-300 hover:hover:text-orange-500 transition-colors font-bold text-[1.5rem] outline-none"
                onClick={event => {
                  event.preventDefault()
                  navigate('/alterarasenha')
                }}
              >
                Esqueceu sua senha?
              </button>
            </div>
            <div className="flex flex-col items-center gap-8 w-full">
              <button
                disabled={loading || email.length === 0 || password.length < 8}
                className="text-white font-bold lg:text-[2rem] text-[17px] py-5 lg:py-5 bg-orange-300 flex justify-center w-[35%] rounded-[5px] outline-none hover:bg-orange-500 focus:bg-orange-500 transition-colors disabled:opacity-50 disabled:cursor-not-allowed"
                type="submit"
              >
                {loading ? <LoadingDeafult /> : 'Logar'}
              </button>
              <button
                onClick={event => {
                  event.preventDefault()
                  navigate('/cadastrar')
                }}
                className="text-white font-bold lg:text-[2rem] text-[17px] px-3 py-5 bg-orange-300 flex justify-center first-letter w-auto sm:w-[40%] rounded-[5px] outline-none hover:bg-orange-500 focus:bg-orange-500 transition-colors"
              >
                Não tem uma conta?
              </button>
            </div>
          </form>
        </div>
      ) : (
        <div className="flex flex-col items-center gap-[1.313rem] pt-[9.2rem] pb-7 px-6">
          <img src={Logo} alt="logo" />
          <form
            onSubmit={handleCreateUser}
            className="flex flex-col items-center justify-between gap-[1.85rem] bg-zinc-500 rounded-[8px] p-5 w-full lg:max-w-[72.5rem]"
          >
            <div className="flex flex-col w-full items-center gap-5">
              <label
                for="User"
                className="text-orange-300 font-bold text-[2.25rem]"
              >
                Nome
              </label>
              <input
                type="text"
                id="User"
                name="User"
                placeholder="Digite seu nome no mínimo 3 dígitos"
                onChange={event => setName(event.target.value)}
                className={`bg-zinc-300 rounded-[5px] px-5 h-20 w-full lg:max-w-lg placeholder-black placeholder:text-[15px]  text-[15px] outline-0
              focus:outline-none focus:border focus:ring-green-300 focus:border-green-300 hover:border-green-300 hover:border invalid:text-red-500 focus:invalid:border-red-500 transition-all duration-500 ease-in-out ${
                name.length < 3 ? 'focus:border-red-500 text-red-500' : ''
              }`}
                required
              />
              <label
                for="Email"
                className="text-orange-300 font-bold text-[2.25rem]"
              >
                Email
              </label>
              <input
                type="email"
                id="Email"
                name="Email"
                placeholder="Digite o seu Email"
                onChange={event => setEmail(event.target.value)}
                className="bg-zinc-300 rounded-[5px] px-5 h-20 w-full lg:max-w-lg placeholder-black placeholder:text-[15px] 
              text-[15px] outline-0
              focus:outline-none focus:border focus:ring-green-300 focus:border-green-300 hover:border-green-300 hover:border invalid:text-red-500 focus:invalid:border-red-500 transition-all duration-500 ease-in-out"
                required
              />
              <label
                for="Password"
                className="text-orange-300 font-bold text-[2.25rem]"
              >
                Senha
              </label>
              <div className="flex flex-col w-full items-center gap-5 relative">
                <input
                  type={eye ? 'text' : 'password'}
                  id="Password"
                  name="Password"
                  placeholder="Digite sua senha no mínimo 8 dígitos"
                  onChange={event => setPassword(event.target.value)}
                  className={`bg-zinc-300 rounded-[5px] px-5 h-20 w-full lg:max-w-lg placeholder-black placeholder:text-[15px] text-[15px] outline-0
              focus:outline-none focus:border focus:ring-green-300 focus:border-green-300 hover:border-green-300 hover:border invalid:text-red-500 focus:invalid:border-red-500 ${
                password.length < 8 ? 'focus:border-red-500 text-red-500' : ''
              } transition-all duration-500 ease-in-out`}
                  required
                />
                <button
                  className="absolute top-0 bottom-0 right-0 lg:right-80 pr-3 lg:pr-0 cursor-pointer"
                  onClick={event => {
                    event.preventDefault()
                    eye ? setEye(false) : setEye(true)
                  }}
                >
                  {eye ? <Eye size={30} /> : <EyeClosed size={30} />}
                </button>
              </div>
            </div>
            <div className="flex flex-col items-center gap-8 w-full">
              <button
                disabled={
                  loading ||
                  email.length === 0 ||
                  password.length < 8 ||
                  name.length < 3
                }
                className="text-white font-bold lg:text-[2rem] text-[17px] px-3 py-5 lg:py-5 bg-orange-300 flex justify-center first-letter w-auto sm:w-[35%] rounded-[5px] outline-none hover:bg-orange-500 focus:bg-orange-500 transition-colors disabled:opacity-50 disabled:cursor-not-allowed"
                type="submit"
              >
                {loading ? <LoadingDeafult /> : 'Finalizar cadastro'}
              </button>
              <button
                onClick={event => {
                  event.preventDefault()
                  navigate('/')
                }}
                className="text-white font-bold lg:text-[2rem] text-[17px] px-3 py-5 lg:py-5 bg-orange-300 flex justify-center first-letter w-auto sm:w-[40%] rounded-[5px] outline-none hover:bg-orange-500 focus:bg-orange-500 transition-colors"
              >
                Já tem uma conta?
              </button>
            </div>
          </form>
        </div>
      )}
      <Footer />
    </>
  )
}
