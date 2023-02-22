module.exports = {
    content: [
        "./node_modules/flowbite/**/*.js",
        "./wwwroot/js/*.js",
        "./Views/**/*.{cshtml,js}"
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('flowbite/plugin')
    ]
}