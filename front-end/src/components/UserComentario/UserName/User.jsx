import React from 'react'

function UserIcon() {
  return (
    <>
      <svg
      className='mr-4 h-16'
        xmlns="http://www.w3.org/2000/svg"
        width="56"
        height="56"
        fill="none"
        viewBox="0 0 56 56"
      >
        <circle cx="28" cy="28" r="28" fill="#000"></circle>
        <path
          fill="#fff"
          d="M27.5 30.063a7.033 7.033 0 007.031-7.032A7.033 7.033 0 0027.5 16a7.033 7.033 0 00-7.031 7.031 7.033 7.033 0 007.031 7.032zm6.25 1.562h-2.69a8.51 8.51 0 01-7.12 0h-2.69a6.25 6.25 0 00-6.25 6.25v.781A2.344 2.344 0 0017.344 41h20.312A2.344 2.344 0 0040 38.656v-.781a6.25 6.25 0 00-6.25-6.25z"
        ></path>
      </svg>
      <h2 className="text-[2rem] font">Nome do usuario</h2>
    </>
  )
}

export default UserIcon
