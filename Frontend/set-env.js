const fs = require('fs');
const filePath = './src/environments/environment.prod.ts';
const apiUrl = process.env.NG_APP_API_URL || 'https://default.com';

const content = `export const environment = {
  production: true,
  apiUrl: '${apiUrl}'
};`;

fs.writeFileSync(filePath, content);
console.log('✔️ environment.prod.ts actualizado con apiUrl:', apiUrl);