< !DOCTYPE html >
    <html lang="en">
        <head>
            <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>O'zbekiston Xaritasi</title>
                    <style>
                        body {
                            background - color: #ffffff; /* Qo'shimcha: Orqa fon rangi */
        }

                        #uzbekistan-map {
                            width: 100%;
                        height: auto;
        }

                        #viloyatlar {
                            fill: #ff0000; /* Qo'shimcha: Viloyat rangi (kok) */
        }
                    </style>
                </head>
                <body>

                    <svg id="uzbekistan-map" xmlns="http://www.w3.org/2000/svg" viewBox="21.82 25.88 30.49 22.29">
                        <!-- O'zbekiston hududi (hali ham xotira qilingan SVG kod) -->

                        <g id="viloyatlar">
                            <!-- Har bir viloyat uchun kerak bo'lgan joylashuvlar -->
                            <path d="M ..." /> <!-- Toshkent viloyati uchun kerak bo'lgan hudud ko'rsatkichi -->
                            <path d="M ..." /> <!-- Samarqand viloyati uchun kerak bo'lgan hudud ko'rsatkichi -->
                            <!-- Qolgan viloyatlar uchun ham shu ko'rinishda davom eting -->

                            <!-- Qo'shimcha: Viloyatlar orasidagi joynashuv chizish -->
                            <line x1="..." y1="..." x2="..." y2="..." stroke="#000000" stroke-width="1" />
                        </g>

                    </svg>

                </body>
            </html>
