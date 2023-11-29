import { FC, PropsWithChildren } from 'react';

// _comps
import { AppBar } from '@/_comps/secure/shared/appbar';

type SecureLayoutProps = PropsWithChildren<{}>;

const SecureLayout: FC<SecureLayoutProps> = ({ children }) => {
	return (
		<>
			{/** header */}
			<AppBar />

			{children}

			{/** footer */}
			<section className='apollo-footer'></section>
		</>
	);
};

export default SecureLayout;
