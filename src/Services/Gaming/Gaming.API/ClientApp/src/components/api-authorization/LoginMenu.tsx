import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';

interface LoginMenuState {
  isAuthenticated: boolean,
  userName: string | null,
}

export class LoginMenu extends Component<{}, LoginMenuState> {
  constructor(props: {}) {
    super(props);

    this.state = {
      isAuthenticated: false,
      userName: null
    };
  }

  _subscription?: number;

  componentDidMount() {
    this._subscription = authService.subscribe(() => this.populateState());
    this.populateState();
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  async populateState() {
    const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
    this.setState({
      isAuthenticated,
      userName: user && user.name
    });
  }

  render() {
    const { isAuthenticated, userName } = this.state;
    if (!isAuthenticated) {
      const registerPath = `${ApplicationPaths.Register}`;
      const loginPath = `${ApplicationPaths.Login}`;
      return this.anonymousView(registerPath, loginPath);
    } else {
      const profilePath = `${ApplicationPaths.Profile}`;
      const logoutPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
      return this.authenticatedView(userName as any, profilePath, logoutPath);
    }
  }

  authenticatedView(userName: {}, profilePath: string, logoutPath: { pathname: string; state: { local: boolean; }; }) {
    return (<Fragment>
      <NavItem>
        <NavLink tag={Link} className="text-dark" to="/">桌游大厅</NavLink>
      </NavItem>
      <NavItem>
        <NavLink tag={Link} className="text-dark" to="/counter">跑团</NavLink>
      </NavItem>
      <NavItem>
        <NavLink tag={Link} className="text-dark" to="/fetch-data">版聊</NavLink>
      </NavItem>
      <NavItem>
        <NavLink tag={Link} className="text-dark" to={profilePath}>{userName}</NavLink>
      </NavItem>
      <NavItem>
        <NavLink tag={Link} className="text-dark" to={logoutPath}>登出</NavLink>
      </NavItem>
    </Fragment>);

  }

  anonymousView(registerPath: string, loginPath: string) {
    return (<Fragment>
      <NavItem>
        <NavLink tag={Link} className="text-dark" to={registerPath}>注册</NavLink>
      </NavItem>
      <NavItem>
        <NavLink tag={Link} className="text-dark" to={loginPath}>登录</NavLink>
      </NavItem>
    </Fragment>);
  }
}
