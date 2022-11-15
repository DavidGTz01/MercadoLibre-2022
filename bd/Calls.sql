
CALL
    AltaCliente (
        30,
        'Rosaurita',
        'Pedraza',
        1122334455,
        'rosauritapedraza30@gmail.com',
        'Rous',
        'bangchansit0'
    );

CALL
    AltaCliente (
        44,
        'Evelyn',
        'Siles',
        1136170568,
        'silesevelyn04@gmail.com',
        'Ev3',
        'hope225'
    );

CALL
    AltaCliente (
        09,
        'Magali Lara Aborto',
        'Rodriguez',
        1198778890,
        'maga.rodriguez@gmail.com',
        'Maguis',
        'magui89'
    );

CALL
    Altacliente (
        10,
        'Matias',
        'Moscoso',
        1032547698,
        'matimoscoso10@gmail.com',
        'Mati',
        'matias12345'
    );

CALL
    Altacliente (
        15,
        'David',
        'Tay',
        100000000, -- 9876543210 valor largoooo
        'davidtay15@gmail.com',
        'David',
        'guevara987'
    );

CALL
    AltaProducto (
        111,
        10,
        10500,
        5,
        'Twice - Álbum Eyes wide open',
        '2020-09-26 23:59:38'
    );

CALL
    AltaProducto (
        135,
        10,
        9850,
        13,
        'BTS - Álbum Butter',
        '2021-05-21 00:01:05'
    );

CALL
    AltaProducto (
        190,
        10,
        11000,
        1,
        ' Stray Kids - Álbum Circus',
        '2022-03-06 00:00:11'
    );

CALL
    AltaProducto (
        227,
        15,
        14000,
        8,
        'Seventeen - Light Stick CARAT Bong Original',
        '2020-12-21 12:02:49'
    );

CALL
    AltaProducto (
        211,
        15,
        18000,
        17,
        'BlackPink- Bl-ping-bong Original',
        '2020-05-28 00:00:17'
    );

CALL
    AltaProducto (
        235,
        15,
        15000,
        10,
        'Twice - Light Stick', -- Candy Bong Z Original Bluetooth (muy largo dice)
        '2021-12-15 12:05:31'
    );

CALL
    AltaProducto (
        372,
        09,
        1800,
        1,
        'Seventeen - PhotoCard Vernon Original',
        '2021-02-01 13:04:53'
    );

CALL AltaCompra (418, 111, 30, 1, 10500, '2022-04-01 23:28:22');

CALL AltaCompra (421, 235, 30, 2, 30000, '2022-04-01 23:35:19');

CALL AltaCompra (426, 211, 30, 1, 18000, '2022-04-01 23:41:13');

CALL AltaCompra ( 442 , 111, 44, 1, 10500, '2022-04-04 09:30:59');

CALL AltaCompra (444, 227, 44, 1, 14000, '2022-04-04 09:39:11');

CALL AltaCompra (450, 372, 44,1 , 1800, '2022-04-04 09:53:26');

CALL AltaCompra (453,190, 44,1 , 11000, '2022-04-04 09:59:24');

CALL AltaCompra (497, 135, 09, 1, 9850, '2022-04-08 17:35:47');

CALL AltaCompra (500, 211, 09, 2, 36000, '2022-04-08 17:40:05');

CALL AltaCompra (502, 190 , 09, 1, 11000, '2022-04-08 17:44:03');