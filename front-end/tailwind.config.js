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
      }
    }
  },
  plugins: []
}
