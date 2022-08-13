import React from 'react'
import Logo from '../assets/Logo.svg'

// Type -> Default/DefaultUser
export default function Header({type}) {
  return (
    <header className='bg-zinc-500 flex items-center px-4 fixed top-0 w-full h-[7.2rem]'>
    {
      type === 'default' ?(
        <div>
          <img src={Logo} alt="Logo do blog"/>
        </div>
      ) : (
        <p>Header com usuario logado</p>
      )
    }
    </header>
  )
}