import { FC, PropsWithChildren } from 'react';
import type { Metadata } from 'next';

// styles
import './layout.css';

type LayoutProps = PropsWithChildren<{}>;

const Layout: FC<LayoutProps> = ({ children }) => {
	return (
		<html lang='en'>
			<body>
				{children}
			</body>
		</html>
	);
};

export const metadata: Metadata = {
	title: {
		default: 'apollo',
		template: '%s / apollo'
	}
};

export default Layout;
