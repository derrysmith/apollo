import type { Config } from 'tailwindcss';

const config: Config = {
	content: [
		'./src/**/*.{js,jsx,mdx,ts,tsx}'
	],
	plugins: [require('daisyui')]
};

export default config;
