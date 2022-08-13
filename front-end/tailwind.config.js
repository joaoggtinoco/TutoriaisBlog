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
        'lg' : '1083px',
        // => @media (min-width: 1083px) { ... }
      }
    }
  },
  plugins: []
}
