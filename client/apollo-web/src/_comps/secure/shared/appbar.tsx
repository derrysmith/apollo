'use client';

import { FC, useEffect, useState } from 'react';
import { usePathname } from 'next/navigation';

// icons
import { MenuIcon, SignOutIcon } from '@/_icons';

const getAppBarTitle = (p: string): string => {
	const match = /^\/(.+?)(\/.*)?$/gm.exec(p);
	if (!!match) return match[1];
	return '';
};

export const useAppBar = () => {
	const pathname = usePathname();
	const [appBarTitle, setAppBarTitle] = useState('');

	useEffect(() => {
		console.log('calling setAppBarTitle from appbar.tsx');
		setAppBarTitle(getAppBarTitle(pathname));
	}, [pathname]);

	return {
		appBarTitle,
		setAppBarTitle
	};
};

export const AppBar: FC = () => {
	const { appBarTitle } = useAppBar();

	return (
		<>
			<div className='navbar bg-[#6090C0] p-0 min-h-0'>
				<div className='navbar-start'>
					<label tabIndex={0} className=''>
						<MenuIcon className='w-8 h-8' />
					</label>
				</div>

				<div className='navbar-center'>
					<a href='#' className='capitalize'>{appBarTitle}</a>
				</div>

				<div className='navbar-end'>
					<label tabIndex={0} className='avatar placeholder'>
						<div className='bg-primary text-primary-content rounded-full w-8'>
							<span className='text-xs uppercase'>DS</span>
						</div>
					</label>
				</div>
			</div>
		</>
	);
};