import React from 'react'
import Logo from '../assets/Logo.svg'
import UserIcon from '../assets/user-circle.svg'

import { useNavigate } from 'react-router-dom'

// Type -> Default/DefaultUser
export default function Header({ type }) {
  const [modal, setModal] = React.useState(false)

  const navigate = useNavigate()

  return (
    <header className="bg-zinc-500 px-4 fixed z-10 top-0 w-full h-[7.2rem]">
      {type === 'default' ? (
        <div className="flex items-center">
          <img src={Logo} alt="Logo do blog" />
        </div>
      ) : (
        <div className="flex items-center justify-between">
          <img src={Logo} alt="Logo do blog" />
          <button className="text-zinc-300 hover:hover:text-orange-300 transition-colors font-bold text-[1.5rem] outline-none">
            Novas Publicações
          </button>
          <img
            className="cursor-pointer"
            src={UserIcon}
            alt="icone do usuário com um menu ao ser clicado"
            onClick={() => {
              modal ? setModal(false) : setModal(true)
            }}
          />
          <div
            className={`absolute bg-zinc-300 top-28 right-4 p-[1.315rem] ${
              modal ? 'flex' : 'hidden'
            } rounded-[10px] shadow-5xl`}
            onMouseLeave={() => {
              modal ? setModal(false) : setModal(true)
            }}
          >
            <div className="flex flex-col justify-between items-center  rounded-[10px] bg-zinc-500 p-[1.88rem] gap-[2.83rem] shadow-4xl">
              <button className="text-orange-300 font-bold text-[1.8rem] outline-none hover:text-orange-500 focus:text-orange-500 transition-colors">
                Config
              </button>
              <button className="text-orange-300 font-bold text-[1.8rem] outline-none hover:text-orange-500 focus:text-orange-500 transition-colors">
                Meus blogs
              </button>
              <button
                onClick={() => {
                  navigate('/')
                }}
                className="text-red-500 font-bold text-[1.8rem] outline-none hover:text-red-600 focus:text-red-600 transition-colors"
              >
                Sair
              </button>
            </div>
          </div>
        </div>
      )}
    </header>
  )
}
