import { withAuthenticationRequired } from '@auth0/auth0-react'
import Load from '../components/shared/Load.js'

const RouteSecurity = ({ component, ...args }) => {
    const SecureComp = withAuthenticationRequired(component, { onRedirecting: () => <Load /> })
    return <SecureComp {...args} />
}

export default RouteSecurity