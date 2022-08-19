/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.jsx'],
  theme: {
    extend: {
      backgroundImage: {
        // blur: 'url(/src/assets/image/blur-background.png)'
      },
      fontFamily: {
        sans: 'Roboto, sans-serif'
      },
      colors: {
        zinc: {
          300: '#AFAFAF',
          500: '#484848'
        },
        orange: {
          300: '#FF9900',
          500: '#B06C05',
        },
        red: {
          500: '#F75A68',
        }
      },
      screens :{
        // Lembrando que eu poderia colocar outro nome para a tela de mobile em vez de lg que ja é padrão do tailwind
        'lg' : '1083px',
        // => @media (min-width: 1083px) { ... }
      },
      boxShadow :{
        // 4xl não é padrão do tailwind, eu mesmo criei
        '4xl' : '5px 5px 5px 4px rgba(0, 0, 0, 0.25)',
        '5xl' : '0px 5px 5px rgba(0, 0, 0, 0.25)'
      }
    }
  },
  plugins: []
}
