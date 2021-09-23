/*
 * Copyright 2013 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
package org.gradle.nativeplatform.platform.internal;

import org.gradle.internal.os.OperatingSystem;
import org.gradle.nativeplatform.OperatingSystemFamily;

public class DefaultOperatingSystem implements OperatingSystemInternal {
    private static final OperatingSystem CURRENT_OS = OperatingSystem.current();

    private final String name;
    private final OperatingSystem internalOs;

    public DefaultOperatingSystem(String name) {
        this(name, OperatingSystem.forName(name));
    }

    public DefaultOperatingSystem(String name, OperatingSystem internalOs) {
        this.name = name;
        this.internalOs = internalOs;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public String getDisplayName() {
        return "operating system '" + name + "'";
    }

    @Override
    public String toString() {
        return getDisplayName();
    }

    @Override
    public OperatingSystem getInternalOs() {
        return internalOs;
    }

    @Override
    public String toFamilyName() {
        if (isWindows()) {
            return OperatingSystemFamily.WINDOWS;
        } else if (isLinux()) {
            return OperatingSystemFamily.LINUX;
        } else if (isMacOsX()) {
            return OperatingSystemFamily.MACOS;
        } else {
            throw new UnsupportedOperationException("Unsupported operating system family of name '" + name + "'");
        }
    }

    @Override
    public boolean isCurrent() {
        return internalOs == CURRENT_OS;
    }

    @Override
    public boolean isWindows() {
        return internalOs.isWindows();
    }

    @Override
    public boolean isLinux() {
        return internalOs.isLinux();
    }

    @Override
    public boolean isMacOsX() {
        return internalOs.isMacOsX();
    }

    @Override
    public boolean isSolaris() {
        return internalOs == OperatingSystem.SOLARIS;
    }

    @Override
    public boolean isFreeBSD() {
        return internalOs == OperatingSystem.FREE_BSD;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }
        DefaultOperatingSystem that = (DefaultOperatingSystem) o;
        return name.equals(that.name);
    }

    @Override
    public int hashCode() {
        return name.hashCode();
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  �PNG

   IHDR         ���   bKGD � � �����   	pHYs   H   H F�k>   	vpAg       �d$  IDAT8��1o�f���(RE*�l�6��[uq��@�z��]�0�_P��=��^<ٻ��h�j!�����r�4��uY8(��@��D|$���w�������X������V� *@d��	�]�V{�������^��|tU���8�P�I��z���g��[�u ,�PU
uQ��[����E�w>��e������	�q[a� loo�GGG�4M#�=��/��`�ax�5?��Fs5�������v�������r��t~ ̌�d�����7��������w��A���������Q�ݾ���s���4UUE�WY��3CU�e�����{����V�E�z�R���������z,L��ů�>���pzz�{xxH��������K���ﷆ��n��t�Qi��O�P՚� "��;0)�(=��������^�q���сz��!jzm����qs4}���J��aj�T�V�+A``j���x<n<~�x?�D� p�~��@M��q8T3����^�LD$�3�4M'x���lIgi�}��{/���K���"�����z=�L�lI�"N3TgQ0��)S3�͖��PSDg�*���&����^101�3ә)|��K5j^���U����H����jR@�Zb^A�k>��]�t<_���?��Y���$}^&y��?�M�窊y%M�Y��,��޿�8�e�:?ð�V+9??�,E����d2�Y��Y�YoNNN����%Ib@����q��l�3�T!   %tEXtdate:create 2010-10-14T09:52:41-07:00�K0   %tEXtdate:modify 2010-10-14T09:52:41-07:00�P�   tEXtSoftware Adobe ImageReadyq�e<    IEND�B`�                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           